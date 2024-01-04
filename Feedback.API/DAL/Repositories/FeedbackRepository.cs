using Feedback.API.DAL.Repositories.IRepositories;
using MongoDB.Driver;

namespace Feedback.API.DAL.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly IConfiguration _configuration;

        public FeedbackRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IMongoCollection<T> ConnectToMongo<T>(string collection)
        {
            var client = new MongoClient(_configuration["MongoSetting:ConnectionString"]);
            var db = client.GetDatabase(_configuration["MongoSetting:DatabaseName"]);
            return db.GetCollection<T>(collection);
        }

        public async Task Create(Models.Response.Feedback item)
        {
            var collection = ConnectToMongo<Models.Response.Feedback>(_configuration["MongoSetting:ColumnName"]);
            await collection.InsertOneAsync(item);
        }

        public async Task<List<Models.Response.Feedback>> Get()
        {
            var collection = ConnectToMongo<Models.Response.Feedback>(_configuration["MongoSetting:ColumnName"]);
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<Models.Response.Feedback> Get(Guid id)
        {
            var collection = ConnectToMongo<Models.Response.Feedback>(_configuration["MongoSetting:ColumnName"]);
            return await collection.Find(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(Models.Response.Feedback item)
        {
            var collection = ConnectToMongo<Models.Response.Feedback>(_configuration["MongoSetting:ColumnName"]);
            await collection.ReplaceOneAsync(i => i.Id == item.Id, item);
        }

        public async Task Delete(Guid id)
        {
            var collection = ConnectToMongo<Models.Response.Feedback>(_configuration["MongoSetting:ColumnName"]);
            await collection.DeleteOneAsync(i => i.Id == id);
        }
    }
}

