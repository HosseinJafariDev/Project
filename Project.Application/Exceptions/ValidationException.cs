namespace Project.Application.Exceptions;

public class ValidationException(string message) : ApplicationException(message)
{
}