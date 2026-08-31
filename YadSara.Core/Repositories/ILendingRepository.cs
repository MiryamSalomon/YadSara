using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YadSara.Core.Entities;
namespace YadSara.Core.Repositories
{
    public interface ILendingRepository
    {
        public List<Lending> GetAll();
        public List<Lending> GetByTime(DateTime dateTime);

        public List<Lending> GetByLandB(string borrowId, string lenderId);
        public Lending GetById(int id);
        public Lending Update(Lending lending);
        public Lending Delete(int id);
         public Lending Add(Lending lending);

    }
}
