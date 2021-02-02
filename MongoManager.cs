using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace CommonClass
{
    /// <summary>
    /// Mongo DBへの接続クラス
    /// </summary>
    class MongoManager : IDisposable
    {
        public IMongoDatabase db;
        public MongoClient client;

        public MongoManager(string server, string database, string user, string pass,int port = 27017)
        {
            var connectionString = $"mongodb://{user}:{pass}@{server}:{port}/{database}";
            client = new MongoClient(connectionString);
            db = client.GetDatabase(database);
        }

        /// <summary>
        /// Bsonで登録
        /// </summary>
        /// <param name="name"></param>
        /// <param name="doc"></param>
        public void Insert(string name,BsonDocument doc)
        {
            var collection = db.GetCollection<BsonDocument>(name);
            db.CreateCollection(name);
            collection.InsertOne(doc);
        }

        /// <summary>
        /// クラスを登録する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        public void Insert<T>(T obj, string name) where T:class, new()
        {
            var collection = db.GetCollection<T>(name);
            collection.InsertOne(obj);
        }

        public void Dispose()
        {
            db = null;
            client = null;
        }
    }
}
