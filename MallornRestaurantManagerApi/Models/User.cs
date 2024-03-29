using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MallornRestaurantManagerApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("Name")]
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public User()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
    }
}