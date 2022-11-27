using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeWeb.Models {
    public class WeatherModel {
        public WeatherSynopticModel WeatherSynoptic { get; set; }
        public WeatherHydroModel WeatherHydro { get; set; }
    }
}
