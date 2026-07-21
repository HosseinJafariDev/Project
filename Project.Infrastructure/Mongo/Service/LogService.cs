using MongoDB.Driver;
using Project.Application.Interfaces.Service;
using Project.Infrastructure.Mongo.Documents;

namespace Project.Infrastructure.Mongo.Service;

public class LogService(IMongoCollection<LogDocument> collection) : ILogService
{
    public async Task LogAsync(Exception exception)
    {
        var document = new LogDocument
        {
            Message = exception.Message,
            StackTrace = exception.StackTrace,
            Source = exception.Source,
            Type = exception.GetType().FullName,
            CreatedAt = DateTime.UtcNow
        };

        await collection.InsertOneAsync(document);
    }
}