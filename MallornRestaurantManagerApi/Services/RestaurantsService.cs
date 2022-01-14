using MallornRestaurantManagerApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MallornRestaurantManagerApi.Services
{
    public class RestaurantsService
    {
        private readonly IMongoCollection<Restaurant> _restaurantsCollection;

        public RestaurantsService(IOptions<MallornRestaurantDatabaseSettings> mallornRestaurantDatabaseSettings)
        {
            var mongoClient = new MongoClient(mallornRestaurantDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mallornRestaurantDatabaseSettings.Value.DatabaseName);
            _restaurantsCollection = mongoDatabase.GetCollection<Restaurant>(mallornRestaurantDatabaseSettings.Value.RestaurantsCollectionName);
        }

        public async Task<List<Restaurant>> GetAsync() =>
        await _restaurantsCollection.Find(_ => true).ToListAsync();

        public async Task<Restaurant?> GetAsync(string id) =>
            await _restaurantsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Restaurant newRestaurant) =>
            await _restaurantsCollection.InsertOneAsync(newRestaurant);

        public async Task UpdateAsync(string id, Restaurant updateRestaurant) =>
            await _restaurantsCollection.ReplaceOneAsync(x => x.Id == id, updateRestaurant);

        public async Task RemoveAsync(string id) =>
            await _restaurantsCollection.DeleteOneAsync(x => x.Id == id);
    }
}