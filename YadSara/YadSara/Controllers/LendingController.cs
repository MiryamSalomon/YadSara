using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YadSara.Core.Entities;
using YadSara.Core.Services;

namespace YadSara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendingController : ControllerBase
    {
        private readonly ILendingService _lendingService;

        public LendingController(ILendingService lendingService)
        {
            _lendingService = lendingService;
        }

        // GET: api/<LendingController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lending>>> Get()
        {
            return Ok(await _lendingService.GetListAsync());
        }

        // GET api/<LendingController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lending>> Get(int id)
        {
            var lending = await _lendingService.GetLendingAsync(id);
            return lending == null ? NotFound() : Ok(lending);
        }

        // GET api/<LendingController>/by-date/2026-01-01
        [HttpGet("by-date/{date}")]
        public async Task<ActionResult<IEnumerable<Lending>>> GetByDate(DateTime date)
        {
            return Ok(await _lendingService.GetListByDateAsync(date));
        }

        // GET api/<LendingController>/by-borrower-lender?borrowId=x&lenderId=y
        [HttpGet("by-borrower-lender")]
        public async Task<ActionResult<IEnumerable<Lending>>> GetByBorrowerAndLender([FromQuery] string borrowId, [FromQuery] string lenderId)
        {
            return Ok(await _lendingService.GetListLandBAsync(borrowId, lenderId));
        }

        // POST api/<LendingController>
        [HttpPost]
        public async Task<ActionResult<Lending>> Post([FromBody] Lending l)
        {
            try
            {
                var added = await _lendingService.AddLendingAsync(l);
                return CreatedAtAction(nameof(Get), new { id = added.LendingId }, added);
            }
            catch (DbUpdateException)
            {
                return Conflict($"A lending with id '{l.LendingId}' already exists.");
            }
        }

        // PUT api/<LendingController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Lending>> Put(int id, [FromBody] Lending l)
        {
            if (id != l.LendingId)
            {
                return BadRequest("Route id does not match body id.");
            }

            try
            {
                return Ok(await _lendingService.UpdateLendingAsync(l));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<LendingController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _lendingService.DeleteLendingAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
