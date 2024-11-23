using Microsoft.AspNetCore.Mvc;
using YadSara.Core.Repositories;
using YadSara.Core.Services;
using YadSara.Core.Entities;

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
        public IEnumerable<Equipment> Get()
        {
            return _equipmentService.GetList() ;
        }

        // GET api/<EquipmentController>/5
        [HttpGet("{id}")]
        public Equipment Get(int id)
        {
            return _equipmentService.GetEquipment(id);
        }

        // POST api/<EquipmentController>
        [HttpPost]
        public Equipment Post([FromBody] Equipment e)
        {
            return _equipmentService.AddEquipment(e);
        }

        // PUT api/<EquipmentController>/5
        [HttpPut("")]
        public Equipment Put( [FromBody] Equipment e)
        {
          return  _equipmentService.UpdateEquipment(e);

        }

        // DELETE api/<EquipmentController>/5
        [HttpDelete("{idEquipment}")]
        public void Delete(int idEquipment)
        {
            _equipmentService.DeleteEquipment(idEquipment);
        }
    }
}
