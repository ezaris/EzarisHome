using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeWeb.Models {
    public class AstronomyAsteroid {
        public string Explanation { get; set; }
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("nasa_jpl_url")]
		public string Url { get; set; }
		[JsonProperty("is_potentially_hazardous_asteroid")]
		public string IsHazardus { get; set; }
		[JsonProperty("close_approach_data")]
		public string CloseApproachData { get; set; }

	}
}