using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            return _context.Equipment.Include(x=>x.Lender).ToList();
        }
        public Equipment GetById(int id)
        {
            return _context.Equipment.FirstOrDefault(bN => bN.IdEquipment.Equals( id));
        }
        public Equipment Update(Equipment equipment)
        {
            var index = _context.Equipment.ToList().FindIndex(f => f.IdEquipment == equipment.IdEquipment);
            _context.Equipment.ToList()[index].IdEquipment = equipment.IdEquipment;
            _context.Equipment.ToList()[index].NameEquipment = equipment.NameEquipment;
            _context.Equipment.ToList()[index].NameEquipmentck = equipment.NameEquipmentck;
            _context.Equipment.ToList()[index].Currentquantity = equipment.Currentquantity;
            _context.Equipment.ToList()[index].Deposit = equipment.Deposit;
            _context.Equipment.ToList()[index].LenderId = equipment.LenderId;
            _context.SaveChanges();
            return equipment;
        }
        public Equipment Delete(int id)
        {
            var e = GetById(id);
            _context.Equipment.ToList().Remove(e);
            _context.SaveChanges();
            return e;
        }
        public Equipment Add(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            _context.SaveChanges();
            return equipment;
        }

    }
}
