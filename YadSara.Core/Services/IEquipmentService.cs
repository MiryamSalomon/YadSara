using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadSara.Core.Entities;

namespace YadSara.Core.Services
{
    public interface IEquipmentService
    {
        public List<Equipment> GetList();
        public Equipment GetEquipment(int id);
        public Equipment UpdateEquipment(Equipment e);
        public Equipment DeleteEquipment(int id);
        public Equipment AddEquipment(Equipment equipment);

    }
}
