using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadSara.Core.Entities;
namespace YadSara.Core.Repositories
{
    public interface ILenderRepository
    {
        public List<Lender> GetAll();
        public Lender GetById(string id);
        public Lender Update(Lender lender);
        public Lender Delete(string id);
        public Lender Add(Lender lender );

    }
}
