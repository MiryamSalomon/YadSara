using Microsoft.AspNetCore.Mvc;
using YadSara.Core.Entities;
using YadSara.Core.Services;
using YadSara.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YadSara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityControllers : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityControllers(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/<CityController>
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _cityService.GetList();
        }

        // POST api/<CityController>
        [HttpPost]
        public City Post([FromBody] City c)
        {
          return _cityService.AddCity(c);
        }

    }
}
