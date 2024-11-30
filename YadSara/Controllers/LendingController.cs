using Microsoft.AspNetCore.Mvc;
using YadSara.Core.Entities;
using YadSara.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<LeanderController>
        [HttpGet]
        public IEnumerable<Lending> Get()
        {
            return _lendingService.GetList();
        }

        // GET api/<LeanderController>/5
        [HttpGet("{LendingId}")]
        public Lending Get(int lenderId)
        {
            return _lendingService.GetLending(lenderId);
        }
        // GET api/<LeanderController>/5
        [HttpGet("{isReturnAndDeadlin}")]
        public IEnumerable<Lending> Get(DateTime dateTime)
        {
            return _lendingService.GetListByDate(dateTime);
            
        }
        // GET api/<LeanderController>/5
        [HttpGet("{s}")]
        public IEnumerable<Lending> Get(string borrowId, string lenderId)
        {
            return _lendingService.GetListLandB(borrowId, lenderId);

        }
        // POST api/<LeanderController>
        [HttpPost]
        public Lending Post([FromBody] Lending l)
        {
            return _lendingService.AddLending(l);
        }

        // PUT api/<LeanderController>/5
        [HttpPut("{id}")]
        public Lending Put([FromBody] Lending l)
        {
            return _lendingService.UpdateLending(l);
        }

        // DELETE api/<LeanderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          _lendingService.DeleteLending(id);
        }
    }
}
