using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EzarisHomeWeb.Helpers;
using EzarisHomeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EzarisHomeWeb.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            var weatherSynoptic = GetWeather();
            var weatherHydro = GetHydro();
            var weather = new WeatherModel()
            {
                WeatherHydro = weatherHydro,
                WeatherSynoptic = weatherSynoptic
            };

            return View(weather);
        }

        private WeatherSynopticModel GetWeather()
        {
            var apiResponse = RequestHelper.GetRequest("https://localhost:5001/weather");
            var weatherSynoptic = JsonConvert.DeserializeObject<WeatherSynopticModel>(apiResponse.Result);
            return weatherSynoptic;
        }

        private WeatherHydroModel GetHydro()
        {
            var apiResponse = RequestHelper.GetRequest("https://localhost:5001/weather/GetHydroData");
            var WeatherHydro = JsonConvert.DeserializeObject<WeatherHydroModel>(apiResponse.Result);
            return WeatherHydro;
        }
    }
}
