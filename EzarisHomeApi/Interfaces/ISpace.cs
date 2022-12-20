using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeApi.Interfaces {
    public interface ISpace {
        string GetAstronomyPictureOfTheDay();
        string GetAsteroids();
    }
}
