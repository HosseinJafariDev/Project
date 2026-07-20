namespace Project.Application.Exceptions;

public class NotFoundException(string message) : ApplicationLayerException(message)
{
}