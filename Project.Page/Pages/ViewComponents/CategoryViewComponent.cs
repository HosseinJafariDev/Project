using Microsoft.AspNetCore.Mvc;
using Project.Application.UseCases.Categories.GetCategory;
using Project.Page.Mappers;

namespace Project.Page.Pages.ViewComponents;

public class CategoryViewComponent(IGetAllCategoriesUseCase getAllCategoriesUseCase) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var cancellationToken = HttpContext.RequestAborted;

        var categoriesDto = await getAllCategoriesUseCase.ExecuteAsync(cancellationToken);

        var categoriesResponse = categoriesDto.ToCategoriesResponse();

        return View(categoriesResponse);
    }
}