using Project.Application.UseCases.Categories.DeleteCategory;
using Project.Application.UseCases.Categories.EditCategory;
using Project.Application.UseCases.Categories.GetCategory;
using Project.Domain.Entities.Categories;

namespace Project.Application.UseCases.Categories.Mappers;

public static class CategoryDtoMappings
{
    public static List<GetAllCategoriesOutputDto> ToGetAllCategoriesOutputDtos(this IReadOnlyList<Category> categories)
    {
        return categories
            .Select(x => new GetAllCategoriesOutputDto
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToList();
    }

    public static Category ToCategory(this DeleteCategoryInputDto input)
    {
        return new Category(input.Id, input.Name!);
    }

    public static Category ToCategory(this EditCategoryInputDto input)
    {
        return new Category(input.Id, input.Name!);
    }
}