using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace EzarisHomeApi.Helpers {
    public static class JsonHelper {
        public static T ConvertJsonToModel<T>(string Json) {
            var jsonSerializerSettings = new JsonSerializerSettings() {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<T>(Json, jsonSerializerSettings);
        }

        public static IEnumerable<T> ConvertJsonToModelList<T>(string Json) {
            var jsonSerializerSettings = new JsonSerializerSettings() {
                MissingMemberHandling = MissingMemberHandling.Ignore                
            };

            return JsonConvert.DeserializeObject<IEnumerable<T>>(Json, jsonSerializerSettings);
        }

        public static string CreateJson(object payload) {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(payload, serializerSettings);
        }
    }
}
