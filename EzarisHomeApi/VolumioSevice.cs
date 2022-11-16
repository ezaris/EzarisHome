using EzarisHomeApi.Helpers;
using EzarisHomeApi.Interfaces;
using EzarisHomeApi.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EzarisHomeApi {
    public class VolumioSevice : IMusicPlayer {
        private const string VOLUMIO_API_BASEURL = "http://volumio.local/api/v1";

        public string GetState() =>
            CallGet(UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "getState")).Result;
        public string Play() =>
            CallGet(UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "commands", new { cmd = "play" })).Result;
        public string Pause() =>
           CallGet(UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "commands", new { cmd = "pause" })).Result;
        public string Stop() =>
           CallGet(UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "commands", new { cmd = "stop" })).Result;
        public string Toggle() =>
           CallGet(UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "commands", new { cmd = "toggle" })).Result;
        public string GetFavouritesRadio() =>
           CallGet(UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "browse", new { uri = "radio/favourites" })).Result;
        public string Play(MusicPlayerStationModel musicPlayerStateModel) {
            var url = UrlHelper.BuildUrl(VOLUMIO_API_BASEURL, "replaceAndPlay");
            var json = JsonHelper.CreateJson(musicPlayerStateModel);
            var payload = new StringContent(json, Encoding.UTF8, "application/json");
            var result = CallPost(url, payload);
            return result.Result.StatusCode.ToString();

        }
        private Task<string> CallGet(string url) {
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(url);
            return response;
        }
        private Task<HttpResponseMessage> CallPost(string url, StringContent payload) {
            HttpClient client = new HttpClient();
            var response = client.PostAsync(url, payload);
            return response;
        }
    }
}
