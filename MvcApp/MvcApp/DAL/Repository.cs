using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcApp.Models;

namespace MvcApp.DAL
{
    public interface IAlertingRepository
    {
        IEnumerable<AlertType> GetAlertTypes();

        AlertType GetAlertType(string id);

        AlertType AddAlertType(AlertType item);

        bool RemoveAlertType(string id);

        bool UpdateAlertType(string id, AlertType item);
    }

    public class AlertingRepository : IAlertingRepository
    {
        MongoDB.Driver.MongoClient _client = null;
        MongoDB.Driver.IMongoDatabase _database = null;
        MongoDB.Driver.IMongoCollection<AlertType> _alertTypes = null;

        public AlertingRepository(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = "mongodb://localhost:27017";
            }

            _client = new MongoDB.Driver.MongoClient(connection);
            _database = _client.GetDatabase("local",  null);
            _alertTypes = _database.GetCollection<AlertType>("alerttypes");

            var filter = new MongoDB.Bson.BsonDocument();
            long count = _alertTypes.Count(filter);

            // AddTestData();
        }


        List<AlertType> FindAllSync()
        {
            List<AlertType> results = new List<AlertType>();

            var count = 0;
            var filter = new MongoDB.Bson.BsonDocument();

            using (var cursor = _alertTypes.FindSync<AlertType>(filter, null))
            {
                while (cursor.MoveNext())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        // process document
                        count++;

                        results.Add(document);
                    }
                }
            }

            return results;
        }

        async System.Threading.Tasks.Task FindAll(MongoDB.Driver.IMongoCollection<AlertType>  collection, List<AlertType> results )
        {
            results = new List<AlertType>();

            var filter = new MongoDB.Bson.BsonDocument();
            var count = 0;
            using (var cursor = await collection.FindAsync<AlertType>(filter,null))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        // process document
                        count++;

                        results.Add(document);
                    }
                }
            }
        }

        public AlertType AddAlertType(AlertType item)
        {
            // throw new NotImplementedException();
            _alertTypes.InsertOne(item);
            return item;
        }

        public AlertType GetAlertType(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AlertType> GetAlertTypes()
        {
            List<AlertType> filteredList = new List<AlertType>();
            filteredList = FindAllSync();

            return filteredList;
        }

        public async System.Threading.Tasks.Task<AlertType> GetAlertTypesAsync()
        {
            var filter = new MongoDB.Bson.BsonDocument();
            return null;            
        }

        public bool RemoveAlertType(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAlertType(string id, AlertType item)
        {
            throw new NotImplementedException();
        }

        private void AddTestData()
        {
            // Reset database and add some default entries 
            // _alertTypes.DeleteMany();
            for (int index = 0; index < 5; index++)
            {
                var alertType = new AlertType
                {
                    Id = index + 1,
                    Name = string.Format("Type{0}", index + 1),
                    Description = string.Format("Test {0}", index + 1),
                    Paramaters = new List<AlertParameter>()
                };
                AddAlertType(alertType);
            }
        }
    }
}