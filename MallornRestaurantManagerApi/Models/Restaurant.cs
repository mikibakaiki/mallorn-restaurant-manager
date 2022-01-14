using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MallornRestaurantManagerApi.Models
{
    public class Restaurant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string RestaurantName { get; set; } = null!;

        public bool Visited { get; set; }

        public decimal Rating { get; set; }

        public string Category { get; set; } = null!;

        public string? Url { get; set; }

        public DateTime LastVisited { get; set; }

        public User? Author { get; set; }

        public Restaurant()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
    }
}