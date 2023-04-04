using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data;
using TicketHive.Server.Enums;
using TicketHive.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var identityConnectionString = builder.Configuration.GetConnectionString("IdentityDbConnection") ?? throw new InvalidOperationException("Connection string 'IdentityDbConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(identityConnectionString));

var mainConnectionString = builder.Configuration.GetConnectionString("MainDbConnection") ?? throw new InvalidOperationException("Connection string 'MainDbConnection' not found.");
builder.Services.AddDbContext<MainDbContext>(options =>
	options.UseSqlServer(mainConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>()
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
	.AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
	{
		options.IdentityResources["openid"].UserClaims.Add("role");
		options.ApiResources.Single().UserClaims.Add("role");
	});

builder.Services.AddAuthentication()
	.AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Create ApplicationUser with Admin role
using (var serviceProvider = builder.Services.BuildServiceProvider())
{
	// Create instances from DI container 
	var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
	var signInManager = serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
	var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

	// Create database if it doesn't already exist 
	context.Database.Migrate();

	// Create role "Admin" if it doesn't exist in the database  
	// Check if role exists in database 
	if (!roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
	{
		// If role "Admin" doesn't exist, create new instance of IdentityRole with name "Admin" 
		IdentityRole adminRole = new()
		{
			Name = "Admin"
		};

		// ...and add to database 
		roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
	}

	// Create an admin user if it doesn't already exist one in the database 
	// Check if admin user exists
	if (signInManager.UserManager.FindByNameAsync("admin").GetAwaiter().GetResult() == null)
	{
		// If admin user doesn't exist, create new ApplicationUser with name "admin"...
		ApplicationUser admin = new()
		{
			UserName = "admin",
			Country = Country.Sweden
		};

		// ...add to database... 
		signInManager.UserManager.CreateAsync(admin, "Password1234!").GetAwaiter().GetResult();

		// ...and add the admin user to the "Admin" role 
		signInManager.UserManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
	}

	// Create a regular user if it doesn't already exist one in the database
	// Check if regular user exists
	if (signInManager.UserManager.FindByNameAsync("user").GetAwaiter().GetResult() == null)
	{
		// If regular user doesn't exist, create new ApplicationUser with name "user"...
		ApplicationUser user = new()
		{
			UserName = "user",
			Country = Country.Sweden
		};

		// ...and add to database
		signInManager.UserManager.CreateAsync(user, "Password1234!").GetAwaiter().GetResult();
	}
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
