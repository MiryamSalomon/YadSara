using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadSara.Core.Entities;

namespace YadSara.Core.Repositories
{
    public interface IBorrowRepository
    {
        public List<Borrow> GetAll();
        public Borrow GetById(string id);
        public Borrow Update(Borrow borrow);  
        public void Delete(string id);
        public Borrow Add(Borrow borrow);



    }
}
