using EzarisHomeApi.Helpers;
using EzarisHomeApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EzarisHomeApi.Services {
    public class ImgwService : IWeather {
        private const string IMGW_API_BASEURL = "https://danepubliczne.imgw.pl/api/data";
        
        public string GetSynopticDataByStation(string city) =>
            RequestHelper.CallGet(UrlHelper.BuildUrl(IMGW_API_BASEURL, $"synop/station/{city}")).Result;
        public string GetHydroData() =>
            RequestHelper.CallGet(UrlHelper.BuildUrl(IMGW_API_BASEURL, $"hydro")).Result;
    }
}
