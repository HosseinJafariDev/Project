using Project.Application.Interfaces.Persistence;
using Project.Application.interfaces.Repository;
using Project.Application.UseCases.Articles.Mappers;

namespace Project.Application.UseCases.Articles.UpdataArticle;

public class UpdateArticleUseCase(IArticleRepository articleRepository, IUnitOfWork unitOfWork) : IUpdateArticleUseCase
{
    public async Task<bool> ExecuteAsync(UpdateArticleInputDto input, CancellationToken cancellationToken)
    {
        var article = input.ToArticle();
        article.UpdatedAted(DateTime.Now);

        articleRepository.Update(article);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}