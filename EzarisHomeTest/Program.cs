using EzarisHomeApi;
using EzarisHomeApi.Helpers;
using EzarisHomeApi.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EzarisHomeTest {
    class Program {
        static void Main(string[] args) {
            ChangeRadiostationTest();
        }

        public static void ChangeRadiostationTest() {
            try {
                var volumioService = new VolumioSevice();
                var radioList = new List<MusicPlayerStationModel>();
                var radioListJson = volumioService.GetFavouritesRadio();

                JObject radioListObject = JObject.Parse(radioListJson);            
                var items = radioListObject["navigation"]["lists"].Children().ToList().FirstOrDefault()["items"].Children().ToList();
                items.ForEach(i => radioList.Add(JsonHelper.ConvertJsonToModel<MusicPlayerStationModel>(i.ToString())));

                //var antyradioPaylod = new MusicPlayerStationModel()
                //{
                //    Service = "webradio",
                //    Type = "webradio",
                //    Title = "Anty Radio",
                //    Icon = "fa fa-microphone",
                //    URI = "http://opml.radiotime.com/Tune.ashx?id=s9608"
                //};

                if(radioList.Any()) {
                    var response = volumioService.Play(radioList.First());
                }
            }
            catch(Exception x) {
                //Log.Error(x.Message);
            }
        }
    }
}
