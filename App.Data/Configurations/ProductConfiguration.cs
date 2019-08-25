using App.Model;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Configurations
{
    public class ProductConfiguration
    {
        public static void Configure() {
            BsonClassMap.RegisterClassMap<Product>(cfg => {
                cfg.AutoMap();
                cfg.SetIgnoreExtraElements(true);
                cfg.MapIdMember(x => x.ProductId);
                cfg.MapMember(x => x.ProductName).SetIsRequired(true);
            });
        }
    }
}
