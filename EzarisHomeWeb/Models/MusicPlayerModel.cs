using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeWeb.Models
{
    public class MusicPlayerModel {
        public MusicPlayerStateModel State { get; set; }
        public List<MusicPlayerStationModel> StationList { get; set; }
    }
}
