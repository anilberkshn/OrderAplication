using MongoDB.Driver;

namespace Core.Repository.Interface
{
    public interface IContext
    {
        public IMongoCollection<T> DbMongoCollectionSet<T>(string collection);
    }
}