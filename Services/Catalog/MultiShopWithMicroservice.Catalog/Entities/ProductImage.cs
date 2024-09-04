using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShopWithMicroservice.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageID { get; set; }
        public string ImageUrl { get; set; }
      
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
