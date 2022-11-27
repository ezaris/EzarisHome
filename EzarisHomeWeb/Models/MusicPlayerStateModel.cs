using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeWeb.Models {
    public class MusicPlayerStateModel {
        public StatusEnum Status { get; set; }
        public string Samplerate { get; set; }
        public string Bitdepth { get; set; }
        public string Volume { get; set; }
        public string Title { get; set; }

        public enum StatusEnum {
            Play,
            Pause,
            Stop
        }
    }
}
