using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YadSara.Core.Entities;
using YadSara.Core.Services;

namespace YadSara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        // GET: api/<EquipmentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> Get()
        {
            return Ok(await _equipmentService.GetListAsync());
        }

        // GET api/<EquipmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> Get(int id)
        {
            var equipment = await _equipmentService.GetEquipmentAsync(id);
            return equipment == null ? NotFound() : Ok(equipment);
        }

        // POST api/<EquipmentController>
        [HttpPost]
        public async Task<ActionResult<Equipment>> Post([FromBody] Equipment e)
        {
            try
            {
                var added = await _equipmentService.AddEquipmentAsync(e);
                return CreatedAtAction(nameof(Get), new { id = added.idEquipment }, added);
            }
            catch (DbUpdateException)
            {
                return Conflict($"Equipment with id '{e.idEquipment}' already exists.");
            }
        }

        // PUT api/<EquipmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Equipment>> Put(int id, [FromBody] Equipment e)
        {
            if (id != e.idEquipment)
            {
                return BadRequest("Route id does not match body id.");
            }

            try
            {
                return Ok(await _equipmentService.UpdateEquipmentAsync(e));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<EquipmentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _equipmentService.DeleteEquipmentAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
