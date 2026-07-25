using Project.Application.Interfaces.Persistence;
using Project.Application.interfaces.Repository;
using Project.Application.UseCases.Articles.Mappers;
using Project.Domain.Entities.Articles;

namespace Project.Application.UseCases.Articles.DeleteArticle;

public class DeleteArticleUseCase(IArticleRepository articleRepository, IUnitOfWork unitOfWork) : IDeleteArticleUseCase
{
    public async Task<bool> ExecuteAsync(DeleteArticleInputDto articleInputDto, CancellationToken cancellationToken)
    {
        var article = articleInputDto.ToArticle();
        article.Delete(articleInputDto.Id);
        article.CreatedAted(articleInputDto.CreatedAt);
        article.UpdatedAted(articleInputDto.Id, articleInputDto.UpdatedAt);
        articleRepository.Update(article);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}