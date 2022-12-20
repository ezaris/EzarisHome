using EzarisHomeApi.Helpers;
using EzarisHomeApi.Interfaces;
using EzarisHomeApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzarisHomeApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class SpaceController : ControllerBase {
        private readonly ISpace _space;
        public SpaceController(ISpace space) {
            _space = space ?? throw new ArgumentNullException(nameof(space));
        }
        [HttpGet]
        public string GetAstronomyPictureOfTheDay() => _space.GetAstronomyPictureOfTheDay();
        [HttpGet]
        public string GetAsteroids() => _space.GetAsteroids();

    }
}
