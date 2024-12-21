using YadSara.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using YadSara.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YadSara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowControllers : ControllerBase
    {
        private readonly IBorrowService _borrowService;
       public BorrowControllers(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        // GET: api/<Borrow>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_borrowService.GetList());
        }

        // GET api/<Borrow>/5
        [HttpGet("{borrowId}")]
        public ActionResult Get(string borrowId)
        {
            var borrow = _borrowService.GetBorrow(borrowId);
            if (borrow == null)
            {
                return NotFound();
            }
            return Ok(borrow);
        }

        // POST api/<Borrow>
        [HttpPost]
        public ActionResult Post([FromBody] Borrow b)
        {
            var borrow = _borrowService.GetBorrow(b.borrowId);
            if (borrow == null)
            {
               return Ok(_borrowService.AddBorrow(b));
            }
            return Conflict();
        }
        // PUT api/<Borrow>/5
        [HttpPut("{borrow}")]
        public ActionResult Put( [FromBody] Borrow b)
        {
            var borrow = _borrowService.GetBorrow(b.borrowId);
            if (borrow == null)
            {
                return NotFound();
            }

            return Ok(_borrowService.UpdateBorrow(b));
        }

        // DELETE api/<Borrow>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string borrowId)
        {

            var borrow = _borrowService.GetBorrow(borrowId);
            if (borrow == null)
            {
                return NotFound();
            }

            return Ok();    
           
        }
    }
}
