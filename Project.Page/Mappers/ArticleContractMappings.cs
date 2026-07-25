using Project.Application.UseCases.Articles.CreateArticle;
using Project.Application.UseCases.Articles.GetArticle;
using Project.Application.UseCases.Categories.GetCategory;
using Project.Domain.Entities.Articles;
using Project.Page.Contracts;
using Project.Page.Contracts.Article;

namespace Project.Page.Mappers;

public static class ArticleContractMappings
{
    public static List<ArticleResponse> ToArticleResponse(this List<GetAllArticleOutputDto> article)
    {
        return article.Select(x => new ArticleResponse()
        {
            Id = x.Id,
            Title = x.Title,
            Content = x.Content,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
            AuthorId = x.AuthorId,
            Categories = x.Categories!.Select(y => new CategoryResponse()
            {
                Id = y.Id,
                Name = y.Name
            }).ToList()
        }).ToList();
    }

    public static CreateArticleInputDto ToArticleInputDto(this ArticleCreateRequest articleCreateRequest)
    {
        return new CreateArticleInputDto()
        {
            Categories = articleCreateRequest.CategoryIds.Select(x => new GetAllCategoriesOutputDto()
            {
                Id = x
            }).ToList(),
            Title = articleCreateRequest.Title,
            Content = articleCreateRequest.Content,
            AuthorId = articleCreateRequest.AuthorId,
        };
    }
}