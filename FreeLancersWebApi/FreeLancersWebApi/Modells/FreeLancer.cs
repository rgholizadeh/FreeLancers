using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace FreeLancersWebApi.Modells
{
    [BsonIgnoreExtraElements]
    public class FreeLancer
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public Guid id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Family { get; set; } = String.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }

        [BsonElement("EmailConfirmed")]
        [JsonPropertyName("EmailConfirmed")]
        public bool IsEmailConfirmed { get; set; }
    }
}
