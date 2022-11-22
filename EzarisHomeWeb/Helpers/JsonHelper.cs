using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeWeb.Helpers {
    public class JsonHelper {
        public static T ConvertJsonToModel<T>(string Json)
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<T>(Json, jsonSerializerSettings);
        }

        public static IEnumerable<T> ConvertJsonToModelList<T>(string Json)
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            return JsonConvert.DeserializeObject<IEnumerable<T>>(Json, jsonSerializerSettings);
        }

        public static string CreateJson(object payload)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(payload, serializerSettings);
        }
    }
}
