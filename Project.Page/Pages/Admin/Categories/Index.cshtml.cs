using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.UseCases.Categories.DeleteCategory;
using Project.Application.UseCases.Categories.EditCategory;
using Project.Application.UseCases.Categories.GetCategory;
using Project.Page.Contracts;
using Project.Page.Mappers;

namespace Project.Page.Pages.Admin.Categories;

public class Index(
    IGetAllCategoriesUseCase getAllCategoriesUseCase,
    IDeleteCategoryUseCase deleteCategoryUseCase,
    IEditCategoryUseCase editCategoryUseCase)
    : PageModel
{
    public List<CategoryResponse> CategoriesList { get; set; }
    [BindProperty] public CategoryRequest CategoryRequest { get; set; }

    [Authorize]
    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        var categoriesDto = await getAllCategoriesUseCase.ExecuteAsync(cancellationToken);

        CategoriesList = categoriesDto.ToCategoriesResponse();
    }


    public async Task<IActionResult> OnPostDeleteAsync(CancellationToken cancellationToken)
    {
        if (!User.IsInRole("Admin"))
            return Forbid();
        await deleteCategoryUseCase.ExecuteAsync(CategoryRequest.ToDeleteCategoryInputDto(), cancellationToken);

        var categoriesDto = await getAllCategoriesUseCase.ExecuteAsync(cancellationToken);

        CategoriesList = categoriesDto.ToCategoriesResponse();

        return Partial("_CategoryTable", this);
    }


    public async Task<IActionResult> OnPostEditAsync(CancellationToken cancellationToken)
    {
        if (!User.IsInRole("Admin"))
            return Forbid();
        await editCategoryUseCase.ExecuteAsync(CategoryRequest.ToEditCategoryInputDto(), cancellationToken);
        var categoriesDto = await getAllCategoriesUseCase.ExecuteAsync(cancellationToken);

        CategoriesList = categoriesDto.ToCategoriesResponse();
        return Partial("_CategoryTable", this);
    }
}