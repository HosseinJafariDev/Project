namespace Project.Application.Interfaces.Service;

public interface ILogService
{
    Task LogAsync(Exception exception);
}