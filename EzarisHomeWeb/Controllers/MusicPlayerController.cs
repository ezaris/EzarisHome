using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EzarisHomeWeb.Helpers;
using EzarisHomeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EzarisHomeWeb.Controllers
{
    public class MusicPlayerController : Controller
    {
        public IActionResult Index()
        {
            var state = GetMusicPlayerState();
            var stationList = GetStationList();

            var musicPlayer = new MusicPlayerModel()
            {
                State = state,
                StationList = stationList
            };

            return View(musicPlayer);
        }

        private MusicPlayerStateModel GetMusicPlayerState()
        {
            var apiResponse = RequestHelper.GetRequest("https://localhost:5001/musicplayer");
            var musicPlayerState = JsonConvert.DeserializeObject<MusicPlayerStateModel>(apiResponse.Result);
            return musicPlayerState;
        }
        private List<MusicPlayerStationModel> GetStationList()
        {
            var radioList = new List<MusicPlayerStationModel>();
            var apiResponse = RequestHelper.GetRequest("https://localhost:5001/musicplayer/GetFavouritesRadio");
            JObject radioListObject = JObject.Parse(apiResponse.Result);
            var items = radioListObject["navigation"]["lists"].Children().ToList().FirstOrDefault()["items"].Children().ToList();
            items.ForEach(i => radioList.Add(JsonHelper.ConvertJsonToModel<MusicPlayerStationModel>(i.ToString())));
            return radioList;
        }
        [HttpPost]
        public string Play(string id) {
            var stationList = GetStationList();
            var station = stationList[int.Parse(id)];
            var url = "https://localhost:5001/musicplayer/AddToQueue";            
            var json = JsonHelper.CreateJson(station);
            var response = RequestHelper.PostRequest(url, json);
            var body =  response.Result.ReadAsStringAsync();
            return body.Result;
        }
    }
}
