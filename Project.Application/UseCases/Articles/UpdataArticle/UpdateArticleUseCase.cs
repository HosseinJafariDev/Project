using System.Net.WebSockets;
using Project.Application.Interfaces.Persistence;
using Project.Application.interfaces.Repository;
using Project.Application.UseCases.Articles.Mappers;
using Project.Domain.Entities.ArticleCategories;

namespace Project.Application.UseCases.Articles.UpdataArticle;

public class UpdateArticleUseCase(
    IArticleRepository articleRepository,
    IArticleCategoryRepository articleCategoryRepository,
    IUnitOfWork unitOfWork) : IUpdateArticleUseCase
{
    public async Task<bool> ExecuteAsync(UpdateArticleInputDto input, CancellationToken cancellationToken)
    {
        var article = input.ToArticle();
        article.UpdatedAted(input.Id, DateTime.Now);
        var result = await articleRepository.GetByIdAsync(article.Id, cancellationToken);
        foreach (var artic in result.ArticleCategories)
        {
            foreach (var item in article.ArticleCategories)
            {
                articleCategoryRepository.Remove(new ArticleCategory(artic.Id, artic.CategoryId, artic.ArticleId));
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }

        articleRepository.Update(article);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}