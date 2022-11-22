using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeWeb.Models {
    public class AstronomyPictureOfTheDayModel {
        public string Date { get; set; }
        public string Explanation { get; set; }
        [JsonProperty("hdurl")]
        public string UrlHd { get; set; }
        [JsonProperty("media_type")]
        public string type { get; set; }
        [JsonProperty("service_version")]
        public string ServiceVersion { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
