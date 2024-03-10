using MongoDB.Driver;

namespace QuickOrder.Adapters.Driven.MongoDB.Core
{
    public interface IMondoDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
