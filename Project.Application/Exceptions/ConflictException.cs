namespace Project.Application.Exceptions;

public class ConflictException(string message) : ApplicationException(message)
{
}