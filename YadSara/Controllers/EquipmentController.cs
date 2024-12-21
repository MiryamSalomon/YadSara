using Microsoft.AspNetCore.Mvc;
using YadSara.Core.Repositories;
using YadSara.Core.Services;
using YadSara.Core.Entities;
using YadSara.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YadSara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
     
        private readonly IEquipmentService _equipmentService;
        public  EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        // GET: api/<EquipmentController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok( _equipmentService.GetList()) ;
        }

        // GET api/<EquipmentController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var equipment = _equipmentService.GetEquipment(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return Ok(equipment);
        }

        // POST api/<EquipmentController>
        [HttpPost]
        public ActionResult Post([FromBody] Equipment e)
        {
            var equipment = _equipmentService.GetEquipment(e.idEquipment);
            if (equipment == null)
            {
                return Ok(_equipmentService.AddEquipment(e));
            }
            return Conflict();
        }

        // PUT api/<EquipmentController>/5
        [HttpPut("")]
        public ActionResult Put( [FromBody] Equipment e)
        {
            var equipment = _equipmentService.GetEquipment(e.idEquipment);
            if (equipment == null)
            {
                return NotFound();
            }

            return Ok(_equipmentService.UpdateEquipment(e));

        }

        // DELETE api/<EquipmentController>/5
        [HttpDelete("{idEquipment}")]
        public ActionResult Delete(int idEquipment)
        {

            var equipment = _equipmentService.GetEquipment(idEquipment);
            if (equipment == null)
            {
                return NotFound();
            }

            return Ok(_equipmentService.DeleteEquipment(idEquipment);
        }
    }
}
