using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoTest
{
    class Loader
    {
        private MongoClient _client;
        private IMongoDatabase _database;

        public Loader()
        {
            Connect();
        }

        private void Connect()
        {
            _client = new MongoClient("mongodb://localhost");
            _database = _client.GetDatabase("Snovhit");
        }

        public async void Find()
        {
            var filter = new BsonDocument("lineId", new BsonDocument("$eq", "1"));
            var collection = _database.GetCollection<BsonDocument>("ReceiverData");

            var result = collection.Count(filter);
            //var documents = result.ToListAsync();
            int i = 1;
        }


        public void Load(string fileName)
        {
            var collection = _database.GetCollection<BsonDocument>("ReceiverData");

            using (var reader = new StreamReader(fileName))
            {
                var line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    var contents = line.Split(' ');
                    var document = new BsonDocument
                    {
                        {"frequency", contents[0]},
                        {"amplitude", contents[1]},
                        {"phase", contents[2]},
                        {"lineId", contents[3]}
                    };
                    collection.InsertOne(document);
                }
            }
        }
    }
}
