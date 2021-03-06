using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using UrlShortner.Common;
using UrlShortner.Models;
using UrlShortner.Service.Database;

namespace UrlShortner.Service
{
    public class MongoDBContext:IContextTest
    {

        private readonly IMongoCollection<ShortenedUrl> _collection;
        public MongoDBContext(string connectionSettings)
        {
            var client = new MongoClient(connectionSettings);
           
            var database = client.GetDatabase("MyReallyAwesomeAndTotallyAmazingMongoDB");
            _collection = database.GetCollection<ShortenedUrl>("WowThisIsATrulyMagnificentCollection");
        }
 
       public async Task InsertAsync (ShortenedUrl uriModel)
        {
            await _collection.InsertOneAsync(uriModel);
        }

        public async Task<ShortenedUrl> GetAsync(string token)
        {
            return (await _collection.FindAsync((x) => x.token == token)).FirstOrDefault();

        }
  
    }
}
