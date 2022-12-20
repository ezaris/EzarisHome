using EzarisHomeWeb.Helpers;
using EzarisHomeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EzarisHomeWeb.Controllers {
    public class SpaceController : Controller {
        public async Task<IActionResult> Index() {
            var apiResponse = RequestHelper.GetRequest("https://localhost:5001/space");              
            var astronomyPictureOfTheDay = JsonConvert.DeserializeObject<AstronomyPictureOfTheDayModel>(apiResponse.Result);
                            
            return View(astronomyPictureOfTheDay);
        }

        public IActionResult Asteroids()
        {
            var apiResponse = RequestHelper.GetRequest("https://localhost:5001/space/GetAsteroids");
            var asteroidList = new List<AstronomyAsteroid>();
            JObject radioListObject = JObject.Parse(apiResponse.Result);
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var items = radioListObject["near_earth_objects"][date].Children().ToList().ToList();
            items.ForEach(i => asteroidList.Add(JsonHelper.ConvertJsonToModel<AstronomyAsteroid>(i.ToString())));

            return View(asteroidList);
        }
    }
}
