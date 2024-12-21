using Microsoft.AspNetCore.Mvc;
using YadSara.Core.Entities;
using YadSara.Core.Services;
using YadSara.Service;

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
        public ActionResult Get()
        {
            return Ok( _lenderService.GetList());
        }

        // GET api/<LenderController>/5
        [HttpGet("{LenderId}")]
        public ActionResult Get(string id)
        {
            var lender = _lenderService.GetLender(id);
            if (lender == null)
            {
                return NotFound();
            }
            return Ok(lender);
        }

        // POST api/<LenderController>
        [HttpPost]
        public ActionResult Post([FromBody] Lender l)
        {
            var lender = _lenderService.GetLender(l.lenderId);
            if (lender == null)
            {
                return Ok(_lenderService.AddLender(l));
            }
            return Conflict();
        }

        // PUT api/<LenderController>/5
        [HttpPut("{id}")]
        public ActionResult Put( [FromBody] Lender l)
        {
            var lender = _lenderService.GetLender(l.lenderId);
            if (lender == null)
            {
                return NotFound();
            }

            return Ok(_lenderService.UpdateLender(l));

        }

        // DELETE api/<LenderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string lenderId)
        {

            var lender =_lenderService.GetLender(lenderId);
            if (lender == null)
            {
                return NotFound();
            }
            
            return Ok(_lenderService.DeleteLender(lenderId););
        }
    }
}
