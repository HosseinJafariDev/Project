using Project.Application.UseCases.Articles.CreateArticle;
using Project.Application.UseCases.Articles.DeleteArticle;
using Project.Application.UseCases.Articles.GetArticle;
using Project.Application.UseCases.Articles.GetArticle.GetById;
using Project.Application.UseCases.Articles.UpdataArticle;
using Project.Application.UseCases.Categories.GetCategory;
using Project.Domain.Entities.Articles;

namespace Project.Application.UseCases.Articles.Mappers;

public static class ArticleDtoMappings
{
    public static List<GetAllArticleOutputDto> MapToListGetAllArticleOutputDto(this IReadOnlyList<Article> articles)
    {
        return articles.Select(x => new GetAllArticleOutputDto
        {
            AuthorId = x.AuthorId,
            Content = x.Content,
            CreatedAt = x.CreatedAt,
            Id = x.Id,
            Title = x.Title,
            UpdatedAt = x.UpdatedAt,
            Categories = x.ArticleCategories!.Select(y => new GetAllCategoriesOutputDto()
            {
                Id = y.CategoryId,
                Name = y.Category!.Name,
            }).ToList(),
        }).ToList();
    }

    public static Article ToArticle(this DeleteArticleInputDto articleInputDto)
    {
        return new Article(articleInputDto.AuthorId, articleInputDto.Title!, articleInputDto.Content!);
    }

    public static Article ToArticle(this CreateArticleInputDto articleInputDto)
    {
        var article = new Article(articleInputDto.AuthorId, articleInputDto.Title!, articleInputDto.Content!);

        foreach (var item in articleInputDto.Categories)
        {
            article.AddCategory(item.Id);
        }

        return article;
    }

    public static Article ToArticle(this UpdateArticleInputDto articleInputDto)
    {
        var article = new Article(articleInputDto.AuthorId, articleInputDto.Title!, articleInputDto.Content!);
        foreach (var item in articleInputDto.Categories)
        {
            article.AddCategory(item.Id);
        }

        return article;
    }

    public static GetByIdOutputDto ToByIdOutputDto(this Article article)
    {
        return new GetByIdOutputDto
        {
            Id = article.Id,
            Content = article.Content,
            AuthorId = article.AuthorId,
            Title = article.Title,
            CreatedAt = article.CreatedAt,
            UpdatedAt = article.UpdatedAt,
            Categories = article.ArticleCategories!.Select(x => new GetAllCategoriesOutputDto()
            {
                Id = x.CategoryId,
                Name = x.Category!.Name
            }).ToList()
        };
    }
}