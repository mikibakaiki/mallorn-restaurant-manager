using MallornRestaurantManagerApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MallornRestaurantManagerApi.Services
{
    public class UsersService
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UsersService(IOptions<MallornRestaurantDatabaseSettings> mallornRestaurantDatabaseSettings)
        {
            var mongoClient = new MongoClient(mallornRestaurantDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mallornRestaurantDatabaseSettings.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<User>(mallornRestaurantDatabaseSettings.Value.UsersCollectionName);
        }
        public async Task<List<User>> GetAsync() =>
                await _usersCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetAsync(string id) =>
            await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<bool> FindByNameAsync(string name) => await _usersCollection.Find(x => x.UserName == name).AnyAsync();

        public async Task<User?> GetByNameAsync(string name) => await _usersCollection.Find(x => x.UserName == name).SingleOrDefaultAsync();

        public async Task CreateAsync(User newUser) => await _usersCollection.InsertOneAsync(newUser);

        public async Task RemoveAsync(string id) =>
            await _usersCollection.DeleteOneAsync(x => x.Id == id);
    }
}