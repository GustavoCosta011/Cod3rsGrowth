using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Extensions.SerializerSettings
{
    public static class SerializerSettings
    {
        public static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }
}