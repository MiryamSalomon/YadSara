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
        public IEnumerable<Borrow> Get()
        {
            return _borrowService.GetList();
        }

        // GET api/<Borrow>/5
        [HttpGet("{borrowId}")]
        public Borrow Get(string borrowId)
        {
            return _borrowService.GetBorrow(borrowId);
        }

        // POST api/<Borrow>
        [HttpPost]
        public Borrow Post([FromBody] Borrow b)
        {
            return _borrowService.AddBorrow(b);
        }

        // PUT api/<Borrow>/5
        [HttpPut("{borrow}")]
        public Borrow Put( [FromBody] Borrow b)
        {
            return _borrowService.UpdateBorrow(b);
        }

        // DELETE api/<Borrow>/5
        [HttpDelete("{id}")]
        public void Delete(string borrowId)
        {
           _borrowService.DeleteBorrow(borrowId);
        }
    }
}
