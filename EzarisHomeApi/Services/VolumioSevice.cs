using EzarisHomeApi.Helpers;
using EzarisHomeApi.Interfaces;
using EzarisHomeApi.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EzarisHomeApi.Services {
    public class VolumioSevice : IMusicPlayer {
        private const string VOLUMIO_API_BASEURL = "http://volumio.local/api/v1";

        public string GetState() =>
            RequestHelper.CallGet(UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "getState")).Result;
        public string Play() =>
            RequestHelper.CallGet(UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "commands", new { cmd = "play" })).Result;
        public string Pause() =>
           RequestHelper.CallGet(UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "commands", new { cmd = "pause" })).Result;
        public string Stop() =>
           RequestHelper.CallGet(UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "commands", new { cmd = "stop" })).Result;
        public string Toggle() =>
           RequestHelper.CallGet(UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "commands", new { cmd = "toggle" })).Result;
        public string GetFavouritesRadio() =>
           RequestHelper.CallGet(UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "browse", new { uri = "radio/favourites" })).Result;
        public string Play(MusicPlayerStationModel musicPlayerStateModel) {
            var url = UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "replaceAndPlay");
            var json = JsonHelper.CreateJson(musicPlayerStateModel);
            var payload = new StringContent(json, Encoding.UTF8, "application/json");
            var result = RequestHelper.CallPost(url, payload);
            return result.Result.StatusCode.ToString();

        }        
    }
}
