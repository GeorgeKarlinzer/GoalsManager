using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace GoalsManager.Web
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(obj, jsonSettings);
            return json;
        }
    }
}
