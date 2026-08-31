using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YadSara.Core.Entities;
using YadSara.Core.Services;

namespace YadSara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/<CityController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> Get()
        {
            return Ok(await _cityService.GetListAsync());
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> Get(int id)
        {
            var city = await _cityService.GetCityAsync(id);
            return city == null ? NotFound() : Ok(city);
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<ActionResult<City>> Post([FromBody] City c)
        {
            try
            {
                var added = await _cityService.AddCityAsync(c);
                return CreatedAtAction(nameof(Get), new { id = added.CityId }, added);
            }
            catch (DbUpdateException)
            {
                return Conflict($"A city with id '{c.CityId}' already exists.");
            }
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<City>> Put(int id, [FromBody] City c)
        {
            if (id != c.CityId)
            {
                return BadRequest("Route id does not match body id.");
            }

            try
            {
                return Ok(await _cityService.UpdateCityAsync(c));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _cityService.DeleteCityAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
