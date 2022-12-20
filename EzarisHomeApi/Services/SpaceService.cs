using EzarisHomeApi.Helpers;
using EzarisHomeApi.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeApi.Services {
    public class SpaceService : ISpace {
        private const string NASA_APOD_API_BASEURL_PLANETARY = "https://api.nasa.gov/planetary/apod";
        private const string NASA_APOD_API_BASEURL_ASTEROIDS = " https://api.nasa.gov/neo/rest/v1/feed";
        private string nasaApiKey;
        private readonly IConfiguration _config;
        public SpaceService(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            nasaApiKey = _config["Data:NasaApiKey"].ToString();

        }
        public string GetAstronomyPictureOfTheDay() =>
           RequestHelper.CallGet(UrlHelper.BuildUrl(NASA_APOD_API_BASEURL_PLANETARY, string.Empty, new { api_key = $"{nasaApiKey }"})).Result;

        public string GetAsteroids()
        {
            var date = DateTime.Now;
            var dateFrom = date.ToString("yyyy/MM/dd");
            var dateTo = date.AddDays(1).ToString("yyyy/MM/dd");

            var parameters = new { start_date = dateFrom, end_date = dateTo, api_key = $"{nasaApiKey }" };

            return RequestHelper.CallGet(UrlHelper.BuildUrl(NASA_APOD_API_BASEURL_ASTEROIDS, string.Empty, parameters)).Result;
        }
    }
}
