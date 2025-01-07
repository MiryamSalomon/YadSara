using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadSara.Core.Entities;

namespace YadSara.Core.Services
{
    public interface ILenderService
    {
        public List<Lender> GetList();
        public Lender GetLender(string id);
        public Lender UpdateLender(Lender l);
        public Lender DeleteLender(string id);
        public Lender AddLender(Lender lender);

    }
}
