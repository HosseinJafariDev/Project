using Project.Application.Exceptions;
using Project.Application.Interfaces.Service;
using Project.Domain.Exceptions;

namespace Project.Page.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, ILogService logService)
    {
        try
        {
            await next(context);
        }
        catch (ApplicationLayerException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (DomainException exception)
        {
            await WriteResponseAsync(context, StatusCodes.Status422UnprocessableEntity, exception.Message);
        }
        catch (Exception ex)
        {
            await logService.LogAsync(ex);
            await WriteResponseAsync(context, StatusCodes.Status500InternalServerError, "Error Server");
        }
    }

    public async Task HandleExceptionAsync(HttpContext context, ApplicationLayerException ex)
    {
        switch (ex)
        {
            case ConflictException:
            {
                await WriteResponseAsync(context, StatusCodes.Status409Conflict, ex.Message);
                break;
            }
            case NotFoundException:
            {
                await WriteResponseAsync(context, StatusCodes.Status400BadRequest, ex.Message);
                break;
            }
            case ValidationException:
            {
                await WriteResponseAsync(context, StatusCodes.Status400BadRequest, ex.Message);
                break;
            }
        }
    }


    public Task WriteResponseAsync(HttpContext context, int statusCode, string message)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(message);
    }
}