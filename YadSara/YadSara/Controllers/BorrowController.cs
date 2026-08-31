using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YadSara.Core.Entities;
using YadSara.Core.Services;

namespace YadSara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _borrowService;

        public BorrowController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        // GET: api/<Borrow>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Borrow>>> Get()
        {
            return Ok(await _borrowService.GetListAsync());
        }

        // GET api/<Borrow>/5
        [HttpGet("{borrowId}")]
        public async Task<ActionResult<Borrow>> Get(string borrowId)
        {
            var borrow = await _borrowService.GetBorrowAsync(borrowId);
            return borrow == null ? NotFound() : Ok(borrow);
        }

        // POST api/<Borrow>
        [HttpPost]
        public async Task<ActionResult<Borrow>> Post([FromBody] Borrow b)
        {
            try
            {
                var added = await _borrowService.AddBorrowAsync(b);
                return CreatedAtAction(nameof(Get), new { borrowId = added.borrowId }, added);
            }
            catch (DbUpdateException)
            {
                return Conflict($"A borrow with id '{b.borrowId}' already exists.");
            }
        }

        // PUT api/<Borrow>/5
        [HttpPut("{borrowId}")]
        public async Task<ActionResult<Borrow>> Put(string borrowId, [FromBody] Borrow b)
        {
            if (borrowId != b.borrowId)
            {
                return BadRequest("Route id does not match body id.");
            }

            try
            {
                return Ok(await _borrowService.UpdateBorrowAsync(b));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<Borrow>/5
        [HttpDelete("{borrowId}")]
        public async Task<IActionResult> Delete(string borrowId)
        {
            var deleted = await _borrowService.DeleteBorrowAsync(borrowId);
            return deleted ? NoContent() : NotFound();
        }
    }
}
