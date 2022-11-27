using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeWeb.Models {
    public class WeatherHydroModel {
        [JsonProperty("id_stacji")]
        public string StationId { get; set; }
        [JsonProperty("stacja")]
        public string StationName { get; set; }
        [JsonProperty("rzeka")]
        public string River { get; set; }
        [JsonProperty("stan_wody")]
        public string WaterStatus { get; set; }
        [JsonProperty("stan_wody_data_pomiaru")]
        public string WaterStatusDate { get; set; }
        [JsonProperty("temperatura_wody")]
        public string Temp { get; set; }
        [JsonProperty("temperatura_wody_data_pomiaru")]
        public string TempDate { get; set; }
    }
}
