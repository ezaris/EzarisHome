using EzarisHomeApi.Models;

namespace EzarisHomeApi.Interfaces {
    public interface IMusicPlayer {
        string Play();
        string Pause();
        string Stop();
        string Toggle();
        string GetState();
        string GetFavouritesRadio();
        string Play(MusicPlayerStationModel json);
    }
}
