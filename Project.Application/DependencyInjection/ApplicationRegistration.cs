using Microsoft.Extensions.DependencyInjection;
using Project.Application.UseCases.Articles.GetArticle;
using Project.Application.UseCases.Articles.GetArticle.GetById;
using Project.Application.UseCases.Auth.Login;
using Project.Application.UseCases.Auth.Logout;
using Project.Application.UseCases.Auth.Password;
using Project.Application.UseCases.Auth.Register;
using Project.Application.UseCases.Categories.CreateCategory;
using Project.Application.UseCases.Categories.DeleteCategory;
using Project.Application.UseCases.Categories.EditCategory;
using Project.Application.UseCases.Categories.GetCategory;

namespace Project.Application.DependencyInjection;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ILoginUseCase, LoginUseCase>();
        services.AddScoped<ILogoutUseCase, LogoutUseCase>();
        services.AddScoped<IForgotPasswordUseCase, ForgotPasswordUseCase>();
        services.AddScoped<IRegisterUseCase, RegisterUseCase>();
        services.AddScoped<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
        services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
        services.AddScoped<IEditCategoryUseCase, EditCategoryUseCase>();
        services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
        services.AddScoped<IGetAllArticleUseCase, GetAllArticleUseCase>();
        services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
        services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
        services.AddScoped<IEditCategoryUseCase, EditCategoryUseCase>();
        services.AddScoped<IGetByIdUseCase, GetByIdUseCase>();
        return services;
    }
}