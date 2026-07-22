using Project.Application.UseCases.Categories.DeleteCategory;
using Project.Application.UseCases.Categories.EditCategory;
using Project.Application.UseCases.Categories.GetCategory;
using Project.Page.Contracts;

namespace Project.Page.Mappers;

public static class CategoryContractMappings
{
    public static List<CategoryResponse> ToCategoriesResponse(this List<GetAllCategoriesOutputDto> categoriesOutputDtos)
    {
        return categoriesOutputDtos
            .Select(x => new CategoryResponse
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToList();
    }

    public static DeleteCategoryInputDto ToDeleteCategoryInputDto(this CategoryRequest categoryRequest)
    {
        return new DeleteCategoryInputDto
        {
            Id = categoryRequest.Id,
            Name = categoryRequest.Name
        };
    }

    public static EditCategoryInputDto ToEditCategoryInputDto(this CategoryRequest categoryRequest)
    {
        return new EditCategoryInputDto
        {
            Id = categoryRequest.Id,
            Name = categoryRequest.Name
        };
    }
}