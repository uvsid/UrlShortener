using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortner.Models
{
    /// <summary>
    /// This a model class representing an entity/row/item in the DB
    /// </summary>
    public class ShortenedUrl
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string token { get; set; }
        public string url { get; set; }

    }
}
