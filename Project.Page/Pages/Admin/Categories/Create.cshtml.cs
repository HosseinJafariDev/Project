using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.UseCases.Categories.CreateCategory;
using Project.Page.Contracts.Categoties;
using Project.Page.Mappers;

namespace Project.Page.Pages.Admin.Categories;

[Authorize(Roles = "Admin")]
public class Create(ICreateCategoryUseCase categoryUseCase) : PageModel
{
    [BindProperty] public CategoryCreateRequest CategoryCreateRequest { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostCreateAsync(CancellationToken cancellationToken)
    {
        var result =
            await categoryUseCase.ExecuteAsync(CategoryCreateRequest!.ToCreateCategoryInputDto(),
                cancellationToken);
        return new JsonResult(result);
    }
}