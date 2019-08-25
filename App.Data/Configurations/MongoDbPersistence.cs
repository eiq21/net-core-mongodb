using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Configurations
{
    public class MongoDbPersistence
    {
        public static void Configure() {
            ProductConfiguration.Configure();
            CategoryConfiguration.Configure();
        }
    }
}
