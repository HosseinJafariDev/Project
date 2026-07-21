namespace Project.Infrastructure.Mongo.Documents;

public class LogDocument
{
    public string? Message { get; set; }

    public string? StackTrace { get; set; }

    public string? Source { get; set; }

    public string? Type { get; set; }

    public DateTime CreatedAt { get; set; }
}