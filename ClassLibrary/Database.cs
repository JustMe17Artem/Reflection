using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassLibrary
{
    public class Database
    {
        public static void AddCarToDatabase(Car car)
        {
            var std = new MongoClient("mongodb://localhost");
            var database = std.GetDatabase("Cars");
            var collection = database.GetCollection<Car>("Car");
            collection.InsertOne(car);
        }
    }
}
