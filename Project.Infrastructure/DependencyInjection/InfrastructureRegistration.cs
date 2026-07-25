using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Project.Application.Interfaces.Persistence;
using Project.Application.interfaces.Repository;
using Project.Application.Interfaces.Service;
using Project.Application.UseCases.Auth.Login;
using Project.Application.UseCases.Auth.Logout;
using Project.Application.UseCases.Auth.Password;
using Project.Application.UseCases.Auth.Register;
using Project.Infrastructure.Mongo;
using Project.Infrastructure.Mongo.Service;
using Project.Infrastructure.Persistence;
using Project.Infrastructure.Persistence.Identity;
using Project.Infrastructure.Persistence.Identity.Options;
using Project.Infrastructure.Persistence.Identity.Service.Login;
using Project.Infrastructure.Persistence.Identity.Service.Logout;
using Project.Infrastructure.Persistence.Identity.Service.Password;
using Project.Infrastructure.Persistence.Identity.Service.Register;
using Project.Infrastructure.Persistence.Identity.Service.UserService;
using Project.Infrastructure.Persistence.Repositories;

namespace Project.Infrastructure.DependencyInjection;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PageDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        services.Configure<AdminOption>(configuration.GetSection("Admin"));

        #region IdentityService

        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<ILogoutService, LogoutService>();
        services.AddScoped<IForgotPasswordService, ForgotPasswordService>();
        services.AddScoped<IRegisterService, RegisterService>();
        services.AddScoped<IdentitySeeder>();
        services.AddScoped<IUserService, UserService>();

        #endregion

        #region Repository

        services.AddScoped<IRegisterService, RegisterService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();

        #endregion

        #region Mongo

        var connectionString =
            configuration.GetConnectionString("MongoDb");

        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("LogProject");

        services.AddSingleton(database);

        services.AddSingleton<MongoDbContext>();
        services.AddScoped<ILogService, LogService>();

        #endregion

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}