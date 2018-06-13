using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.Contracts.Enums;
using EpamLibrary.Contracts.Models.MongoDB;
using EpamLibrary.DAL.Interfaces;
using MongoDB.Driver;

namespace EpamLibrary.DAL.Logging
{
    public class LogWriter : ILogger
    {
        public string ConnectionString
        {
            get => _connectionString;
            set
            {
                _connectionString = value;
                SetDatabase();
            }
        }

        private IMongoDatabase _database;
        private string _connectionString;

        public LogWriter()
        {
            SetDatabase();
        }

        public void WriteLog(LogInfo logInfo, LogKind type)
        {
            var collection = _database.GetCollection<LogInfo>(nameof(type));
            collection.InsertOne(logInfo);
        }

        private void SetDatabase()
        {
            if (string.IsNullOrEmpty(ConnectionString))
                ConnectionString = "mongodb://library-log:EOQHTRhDy2FkBEzYWorxsIGv3lIJvIgHqyQvV2LAabL0dsom58jsZQGw74IGpdCIWQCayqtNx55IrpsQvdwhXg==@library-log.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

            var client = new MongoClient(ConnectionString);
            _database = client.GetDatabase("admin");
        }
    }
}
