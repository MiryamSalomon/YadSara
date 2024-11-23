using Microsoft.AspNetCore.Mvc;
using YadSara.Core.Entities;
using YadSara.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YadSara.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LenderController : ControllerBase
    {
        private readonly  ILenderService _lenderService;
        public LenderController(ILenderService lenderService)
        {
            _lenderService = lenderService;
        }

        // GET: api/<LenderController>
        [HttpGet]
        public IEnumerable<Lender> Get()
        {
            return _lenderService.GetList();
        }

        // GET api/<LenderController>/5
        [HttpGet("{LenderId}")]
        public Lender Get(string id)
        {
            return _lenderService.GetLender(id);
        }

        // POST api/<LenderController>
        [HttpPost]
        public Lender  Post([FromBody] Lender l)
        {
            return _lenderService.AddLender(l);
        }

        // PUT api/<LenderController>/5
        [HttpPut("{id}")]
        public Lender Put( [FromBody] Lender l)
        {
            return _lenderService.UpdateLender(l);

        }

        // DELETE api/<LenderController>/5
        [HttpDelete("{id}")]
        public void Delete(string lenderId)
        {
           _lenderService.DeleteLender(lenderId);
        }
    }
}
