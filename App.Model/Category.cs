using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("CategoryId")]
        public int CategoryId { get; set; }
        [BsonElement("CategoryName")]
        public string CategoryName { get; set; }
        [BsonElement("CategoryDescription")]
        public string CategoryDescription { get; set; }
        public ICollection<Product> Product { get; set; } //c#6 = new HashSet<Product>();
    }
}
