using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YadSara.Core.Entities;
using YadSara.Core.Services;

namespace YadSara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LenderController : ControllerBase
    {
        private readonly ILenderService _lenderService;

        public LenderController(ILenderService lenderService)
        {
            _lenderService = lenderService;
        }

        // GET: api/<LenderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lender>>> Get()
        {
            return Ok(await _lenderService.GetListAsync());
        }

        // GET api/<LenderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lender>> Get(string id)
        {
            var lender = await _lenderService.GetLenderAsync(id);
            return lender == null ? NotFound() : Ok(lender);
        }

        // POST api/<LenderController>
        [HttpPost]
        public async Task<ActionResult<Lender>> Post([FromBody] Lender l)
        {
            try
            {
                var added = await _lenderService.AddLenderAsync(l);
                return CreatedAtAction(nameof(Get), new { id = added.lenderId }, added);
            }
            catch (DbUpdateException)
            {
                return Conflict($"A lender with id '{l.lenderId}' already exists.");
            }
        }

        // PUT api/<LenderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Lender>> Put(string id, [FromBody] Lender l)
        {
            if (id != l.lenderId)
            {
                return BadRequest("Route id does not match body id.");
            }

            try
            {
                return Ok(await _lenderService.UpdateLenderAsync(l));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<LenderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _lenderService.DeleteLenderAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
