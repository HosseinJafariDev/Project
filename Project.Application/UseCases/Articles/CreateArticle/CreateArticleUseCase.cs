using Project.Application.Interfaces.Persistence;
using Project.Application.interfaces.Repository;
using Project.Application.UseCases.Articles.Mappers;

namespace Project.Application.UseCases.Articles.CreateArticle;

public class CreateArticleUseCase(IArticleRepository articleRepository, IUnitOfWork unitOfWork) : ICreateArticleUseCase
{
    public async Task<bool> ExecuteAsync(CreateArticleInputDto articleInputDto, CancellationToken cancellationToken)
    {
        var article = articleInputDto.ToArticle();
        article.CreatedAted(DateTime.Now);

        articleRepository.Add(article);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}