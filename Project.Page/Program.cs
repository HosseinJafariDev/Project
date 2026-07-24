using Microsoft.AspNetCore.Identity;
using Project.Application.DependencyInjection;
using Project.Domain.Entities.Roles;
using Project.Domain.Entities.Users;
using Project.Infrastructure.DependencyInjection;
using Project.Infrastructure.Persistence;
using Project.Infrastructure.Persistence.Identity;
using Project.Page.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddPage();

builder.Services.AddIdentity<User, Role>(options =>
    {
        // Password
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;


        // User
        options.User.RequireUniqueEmail = false;

        // Lockout
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;

        // SignIn
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<PageDbContext>()
    .AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    //اگر لاکین نکرده باشد هدایت میشود به این صفحه 
    options.LoginPath = "/Auth/LoginAjax";
    //اگر لاگین کرده باشه و دسرسی نداشته باشه میاد به این صفحه 
    options.AccessDeniedPath = "/AccessDenied";
});


var app = builder.Build();

app.UseCustomExceptionHandler();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IdentitySeeder>();

    await seeder.SeedRolesAsync();
    await seeder.SeedAdminAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();