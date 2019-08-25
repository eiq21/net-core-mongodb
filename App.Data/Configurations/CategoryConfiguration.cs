using App.Model;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Configurations
{
    public class CategoryConfiguration
    {
        public static void Configure() {
            BsonClassMap.RegisterClassMap<Category>(cfg => {
                cfg.AutoMap();
                cfg.SetIgnoreExtraElements(true);
                cfg.MapIdMember(x => x.Id);
                cfg.MapMember(x => x.CategoryName).SetIsRequired(true);
            });
        }
    }
}
