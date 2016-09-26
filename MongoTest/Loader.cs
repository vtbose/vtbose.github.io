using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
namespace MongoTest
{
    class Loader
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Data> _data; 

        public Loader()
        {
            Connect();
        }

        private async void Connect()
        {
            _client = new MongoClient("mongodb://localhost");
            _database = _client.GetDatabase("Snovhit");
            BsonClassMap.RegisterClassMap<Data>(cm => {
                cm.AutoMap();
                cm.GetMemberMap(c => c.Id).SetElementName("_id");
                cm.GetMemberMap(c => c.Frequency).SetElementName("frequency");
                cm.GetMemberMap(c => c.Amplitude).SetElementName("amplitude");
                cm.GetMemberMap(c => c.Phase).SetElementName("phase");
                cm.GetMemberMap(c => c.LineId).SetElementName("lineId");
            });
            await CreateIndex();

        }

        async Task CreateIndex()
        {
            _data = _database.GetCollection<Data>("ReceiverData");

            //create Index on LineId
            await _data.Indexes.CreateOneAsync(Builders<Data>.IndexKeys.Ascending(_ => _.LineId));
        }

        public async void Find()
        {
            var builder = Builders<Data>.Filter;
            //var filter = new BsonDocument("lineId", new BsonDocument("$eq", "1"));
            var filter = builder.Eq("lineId", "1") & builder.Eq("frequency", "1");
            //var res = collection.Find(filter).ToListAsync().Result;
            var cursor = _data.Find(filter).ToCursor();
            var w1 = new Stopwatch();
            var count = 0;

            w1.Start();
            //using (var cursor = await collection.FindAsync(filter))
            {
                while (cursor.MoveNext())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        //Console.WriteLine(document.Amplitude);
                        ++count;
                    }
                }
            }
            Console.WriteLine("Processing query with " + count +" results - " + w1.ElapsedMilliseconds);

            //foreach (var document in documents)
            //{
            //    Console.WriteLine(document.Amplitude);
            //    break;
            //}
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
