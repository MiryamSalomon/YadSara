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
        public ActionResult Get()
        {
            return Ok(_cityService.GetList());
        }

        // POST api/<CityController>
        [HttpPost]
        public ActionResult Post([FromBody] City c)
        {
            //var city = _cityService.ge(c.CityId);
            //if (city == null)
            //{
                return Ok(_cityService.AddCity(c));
            //}
            //return Conflict();

        }

    }
}
