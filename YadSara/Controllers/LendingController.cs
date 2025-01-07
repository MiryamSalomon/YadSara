using Microsoft.AspNetCore.Mvc;
using System;
using YadSara.Core.Entities;
using YadSara.Core.Services;
using YadSara.Service;

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
        public ActionResult Get()
        {
            return Ok(_lendingService.GetList());
        }

        // GET api/<LeanderController>/5
        [HttpGet("{LendingId}")]
        public ActionResult Get(int lenderId)
        {
            var lending = _lendingService.GetLending(lenderId);
            if (lending == null)
            {
                return NotFound();
            }
            return Ok(lending);
   
        }
        // GET api/<LeanderController>/5
        [HttpGet("{isReturnAndDeadlin}")]
        public ActionResult Get(DateTime dateTime)
        {
            var lending = _lendingService.GetListByDate(dateTime);
            if (lending == null)
            {
                return NotFound();
            }
            return Ok(lending);
            
            
        }
        // GET api/<LeanderController>/5
        [HttpGet("{s}")]
        public ActionResult Get(string borrowId, string lenderId)
        {
            var lending = _lendingService.GetListLandB(borrowId, lenderId);
            if (lending == null)
            {
                return NotFound();
            }
            return Ok(lending);

        }
        // POST api/<LeanderController>
        [HttpPost]
        public ActionResult Post([FromBody] Lending l)
        {
            var lending = _lendingService.GetLending(l.LendingId);
            if (lending == null)
            {
                return Ok(_lendingService.AddLending(l));
            }
            return Conflict();
        }

        // PUT api/<LeanderController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Lending l)
        {
            var lending = _lendingService.GetLending(l.LendingId);
            if (lending == null)
            {
                return NotFound();
            }

            return Ok(_lendingService.UpdateLending(l));
    
        }

        // DELETE api/<LeanderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var lending = _lendingService.GetLending(id);
            if (lending == null)
            {
                return NotFound();
            }

            return Ok(_lendingService.DeleteLending(id));
            
        }
    }
}
