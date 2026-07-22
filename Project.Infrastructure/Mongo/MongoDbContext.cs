using MongoDB.Driver;
using Project.Infrastructure.Mongo.Documents;

namespace Project.Infrastructure.Mongo;

public class MongoDbContext(IMongoDatabase database)
{
    public IMongoCollection<LogDocument> Logs
    {
        get
        {
            return database
                .GetCollection<LogDocument>("Log");
        }
    }
}