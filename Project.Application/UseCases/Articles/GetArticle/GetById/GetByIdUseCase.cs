using Project.Application.Exceptions;
using Project.Application.interfaces.Repository;
using Project.Application.UseCases.Articles.Mappers;

namespace Project.Application.UseCases.Articles.GetArticle.GetById;

public class GetByIdUseCase(IArticleRepository articleRepository) : IGetByIdUseCase
{
    public async Task<GetByIdOutputDto> ExecuteAsync(long id, CancellationToken cancellationToken)
    {
        var article = await articleRepository.GetByIdAsync(id, cancellationToken);
        if (article == null)
        {
            throw new NotFoundException("مقاله پیدا نشد");
        }

        return article.ToByIdOutputDto();
    }
}