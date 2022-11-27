using EzarisHomeApi.Helpers;
using EzarisHomeApi.Interfaces;
using EzarisHomeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase {
        //https://danepubliczne.imgw.pl/apiinfo

        private readonly IWeather _weather;
        private readonly IConfiguration _config;
        public WeatherController(IWeather weather, IConfiguration config)
        {
            _weather = weather ?? throw new ArgumentNullException(nameof(weather));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        [HttpGet]
        public string GetSynopticDataByStation(string city)
        {            
            string defaultCity = _config["Data:DefaultCity"].ToString();
            city = city ?? defaultCity;
            var synopticDataByStationJson = _weather.GetSynopticDataByStation(city);            
            return synopticDataByStationJson;
        }

        [HttpGet("getHydroData")]
        public string GetHydroData()
        {
            var hydroDataJson = _weather.GetHydroData();
            var hydroDataList = JsonHelper.ConvertJsonToModelList<WeatherHydroModel>(hydroDataJson);
            var hydroData = hydroDataList.Where(h => h.StationName == "Szczecin" && h.River == "Odra").First();
            return JsonHelper.CreateJson(hydroData);            
        }
    }
}
