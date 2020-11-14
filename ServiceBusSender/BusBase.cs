using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace ServiceBusSender
{
    public abstract class BusBase
    {
        protected readonly QueueClient _queueClient;
        protected const string QUEUE_NAME = "messages";
        protected const string CONNECTION_STRING = "ServiceBusConnectionString";

        protected static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
        {
            Converters = new List<JsonConverter>() 
            { 
                new StringEnumConverter() 
            }
        };

        public BusBase(IConfiguration configuration)
        {
            _queueClient = new QueueClient(configuration.GetConnectionString(CONNECTION_STRING), QUEUE_NAME);
        }
    }
}
