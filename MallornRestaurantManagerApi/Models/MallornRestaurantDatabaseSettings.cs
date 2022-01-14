namespace MallornRestaurantManagerApi.Models
{
    public class MallornRestaurantDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string RestaurantsCollectionName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;

    }
}