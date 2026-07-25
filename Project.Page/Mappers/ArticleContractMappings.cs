using Project.Application.UseCases.Articles.CreateArticle;
using Project.Application.UseCases.Articles.DeleteArticle;
using Project.Application.UseCases.Articles.GetArticle;
using Project.Application.UseCases.Articles.GetArticle.GetById;
using Project.Application.UseCases.Articles.UpdataArticle;
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

    public static DeleteArticleInputDto ToDeleteArticleInputDto(this ArticleDeleteRequest articleDeleteRequest)
    {
        return new DeleteArticleInputDto()
        {
            AuthorId = articleDeleteRequest.AuthorId,
            Content = articleDeleteRequest.Content,
            Title = articleDeleteRequest.Title,
            CreatedAt = articleDeleteRequest.CreatedAt,
            Id = articleDeleteRequest.Id,
            UpdatedAt = articleDeleteRequest.UpdatedAt,
        };
    }

    public static ArticleResponse ToArticleResponse(this GetByIdOutputDto getByIdOutputDto)
    {
        return new ArticleResponse()
        {
            Id = getByIdOutputDto.Id,
            Title = getByIdOutputDto.Title,
            Content = getByIdOutputDto.Content,
            AuthorId = getByIdOutputDto.AuthorId,
            CreatedAt = getByIdOutputDto.CreatedAt,
            UpdatedAt = getByIdOutputDto.UpdatedAt,
            Categories = getByIdOutputDto.Categories.Select(x => new CategoryResponse()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList()
        };
    }

    public static UpdateArticleInputDto ToUpdateArticleInputDto(this ArticleUpdateRequest articleUpdateRequest)
    {
        return new UpdateArticleInputDto()
        {
            Id = articleUpdateRequest.Id,
            Title = articleUpdateRequest.Title,
            AuthorId = articleUpdateRequest.AuthorId,
            Content = articleUpdateRequest.Content,
            CreateAt = articleUpdateRequest.CreateAt,
            Categories = articleUpdateRequest.Categoies.Select(x => new GetAllCategoriesOutputDto()
            {
                Id = x
            }).ToList()
        };
    }
}