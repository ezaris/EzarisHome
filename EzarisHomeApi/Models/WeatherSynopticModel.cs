using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeApi.Models {
    public class WeatherSynopticModel {
        [JsonProperty("id_stacji")]
        public string StationId { get; set; }
        [JsonProperty("stacja")]
        public string StationName { get; set; }
        [JsonProperty("data_pomiaru")]
        public string MeasureDate { get; set; }
        [JsonProperty("godzina_pomiaru")]
        public string MeasureHour { get; set; }
        [JsonProperty("temperatura")]
        public string Temp { get; set; }
        [JsonProperty("predkosc_wiatru")]
        public string WindSpeed { get; set; }
        [JsonProperty("kierunek_wiatru")]
        public string WindDirection { get; set; }
        [JsonProperty("wilgotnosc_wzgledna")]
        public string RelativeHumidity { get; set; }
        [JsonProperty("suma_opadu")]
        public string TotalPrecipitation { get; set; }
        [JsonProperty("cisnienie")]
        public string Pressure { get; set; }
}
}
