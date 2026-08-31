using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadSara.Core.Entities;

namespace YadSara.Core.Repositories
{
    public interface IEquipmentRepository
    {
        public List<Equipment> GetAll();
        public Equipment GetById(int id);
        public Equipment Update(Equipment equipment);
        public Equipment Delete(int id);
        public Equipment Add(Equipment equipment);

    }
}
