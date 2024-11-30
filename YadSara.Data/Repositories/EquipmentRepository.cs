using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadSara.Data.Repositories
{
    public class EquipmentRepository: IEquipmentRepository
    {
        private readonly DataContext _context;

        public EquipmentRepository(DataContext context)
        {
            _context = context;
        }
        public List<Equipment> GetAll()
        {
            return _context.Equipment.ToList();
        }
        public Equipment GetById(int id)
        {
            return _context.Equipment.FirstOrDefault(bN => bN.idEquipment.Equals( id));
        }
        public Equipment Update(Equipment equipment)
        {
            var index = _context.Equipment.ToList().FindIndex(f => f.idEquipment == equipment.idEquipment);
            _context.Equipment.ToList()[index].idEquipment = equipment.idEquipment;
            _context.Equipment.ToList()[index].nameEquipment = equipment.nameEquipment;
            _context.Equipment.ToList()[index].nameEquipmentck = equipment.nameEquipmentck;
            _context.Equipment.ToList()[index].currentquantity = equipment.currentquantity;
            _context.Equipment.ToList()[index].deposit = equipment.deposit;
            _context.Equipment.ToList()[index].lenderId = equipment.lenderId;
            return equipment;
        }
        public void Delete(int id)
        {
            var index = _context.Equipment.ToList().FindIndex(f => f.idEquipment.Equals(id));
            _context.Equipment.ToList().RemoveAt(index);
        }
        public Equipment Add(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            return equipment;
        }

    }
}
