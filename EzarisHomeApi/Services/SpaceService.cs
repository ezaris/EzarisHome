using EzarisHomeApi.Helpers;
using EzarisHomeApi.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeApi.Services {
    public class SpaceService : ISpace {
        private const string NASA_APOD_API_BASEURL = "https://api.nasa.gov/planetary/apod";
        //private const string NASA_API_KEY = "DiuqqqVt39SSsLVriX3uHLqVLw3tEVcjP3RxfBQ7";
        private string nasaApiKey;
        private readonly IConfiguration _config;
        public SpaceService(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            nasaApiKey = _config["Data:NasaApiKey"].ToString();

        }
        public string GetAstronomyPictureOfTheDay() =>
           RequestHelper.CallGet(UrlHelper.BuildUrl(NASA_APOD_API_BASEURL, string.Empty, new { api_key = $"{nasaApiKey }"})).Result;
    }
}
