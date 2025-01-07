using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadSara.Core.Services;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;


namespace YadSara.Service
{
   
    public class EquipmentService: IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public List<Equipment> GetList()
        {
            return _equipmentRepository.GetAll();
        }
        public Equipment GetEquipment(int id)
        {
            return _equipmentRepository.GetById(id);
        }

        public Equipment UpdateEquipment(Equipment equipment)
        {
            return _equipmentRepository.Update(equipment);
        }
        public Equipment DeleteEquipment(int id)
        {
           return  _equipmentRepository.Delete(id);
        }
        public Equipment AddEquipment (Equipment  equipment)
        {
            return _equipmentRepository.Add(equipment);
        }
    }
}
