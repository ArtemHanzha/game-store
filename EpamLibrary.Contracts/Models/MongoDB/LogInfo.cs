using System;
using System.Net;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EpamLibrary.Contracts.Models.MongoDB
{
    public class LogInfo
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Message { get; set; }
        public DateTime IncidentTime { get; set; }
        public IPAddress UserIp { get; set; }
        public int? ConsumerId { get; set; }

        public LogInfo(string message, IPAddress userIp)
        {
            IncidentTime = DateTime.UtcNow;
        }
        public LogInfo(string message) : this(message, null) { }
        public LogInfo(IPAddress userIp) : this(null, userIp) { }
    }
}
