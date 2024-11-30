using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadSara.Core.Entities;

namespace YadSara.Core.Services
{
    public interface IBorrowService
    {
        public List<Borrow>GetList();   
        public Borrow GetBorrow(string id);
        public Borrow   UpdateBorrow(Borrow borrow);
        public void DeleteBorrow(string id);
        public Borrow AddBorrow(Borrow Borrow);


    }
}
