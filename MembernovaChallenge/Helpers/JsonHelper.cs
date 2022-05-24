using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MembernovaChallenge.Helpers
{
    public static class JsonHelper
    {
        public static T? Deserialize<T>(string json) where T : class
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                };
                return JsonConvert.DeserializeObject<T>(json, settings);
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}
