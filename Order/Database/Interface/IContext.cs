using MongoDB.Driver;

namespace OrderCase.Database.Interface
{
    public interface IContext
    {
        public IMongoCollection<T> DbMongoCollectionSet<T>(string collection);
    }
}