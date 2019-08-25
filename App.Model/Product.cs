using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("ProductId")]
        public int ProductId { get; set; }
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        [BsonElement("UnitPrice")]
        public decimal UnitPrice { get; set; }
        [BsonElement("UnitInStock")]
        public int UnitInStock { get; set; }
        [BsonElement("CategoryId")]
        public int CategoryId { get; set; }
        [BsonElement("ProductId")]
        public Category Category { get; set; }
    }
}
