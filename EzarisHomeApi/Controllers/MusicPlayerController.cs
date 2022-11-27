using EzarisHomeApi.Helpers;
using EzarisHomeApi.Interfaces;
using EzarisHomeApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EzarisHomeApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class MusicPlayerController : ControllerBase {
        private readonly IMusicPlayer _musicPlayer;

        public MusicPlayerController(IMusicPlayer musicPlayer) {
            _musicPlayer = musicPlayer ?? throw new ArgumentNullException(nameof(musicPlayer));
        }

        [HttpGet]
        public string GetState() => _musicPlayer.GetState();
        [HttpGet("play")]
        public string Play() => _musicPlayer.Play();
        [HttpGet("pause")]
        public string Pause() => _musicPlayer.Pause();
        [HttpGet("stop")]
        public string Stop() => _musicPlayer.Stop();
        [HttpGet("toggle")]
        public string Toggle() => _musicPlayer.Toggle();
        [HttpGet("GetFavouritesRadio")]
        public string GetFavouritesRadio() => _musicPlayer.GetFavouritesRadio();
        [HttpPost("AddToQueue")]
        public string Play(MusicPlayerStationModel musicPlayerStationModel) => _musicPlayer.Play(musicPlayerStationModel);
    }
}
