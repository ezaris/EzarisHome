using EzarisHomeWeb.Helpers;
using EzarisHomeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace EzarisHomeWeb.Controllers {
    public class SpaceController : Controller {
        public async Task<IActionResult> Index() {
            var apiResponse = RequestHelper.GetRequest("https://localhost:5001/space");              
            var astronomyPictureOfTheDay = JsonConvert.DeserializeObject<AstronomyPictureOfTheDayModel>(apiResponse.Result);
                            
            return View(astronomyPictureOfTheDay);
        }
    }
}
