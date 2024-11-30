using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadSara.Core.Entities;

namespace YadSara.Core.Services
{
    public interface ILendingService
    {
        public List<Lending> GetList();
        public List<Lending> GetListByDate(DateTime date);
        public List<Lending> GetListLandB(string borrowId, string lenderId);
        public Lending GetLending(int id);
        public Lending UpdateLending(Lending lending);
        public void DeleteLending(int id);
        public Lending AddLending(Lending lending);

    }
}
