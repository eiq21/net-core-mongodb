using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace App.API.ViewModels
{
    public class CategoryViewModel
    {
        public string Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
