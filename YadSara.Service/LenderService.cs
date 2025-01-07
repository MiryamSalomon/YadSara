using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadSara.Core.Services;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;

namespace YadSara.Service
{
    public class LenderService: ILenderService
    {
        private readonly ILenderRepository _lenderRepository;
        public LenderService(ILenderRepository lenderRepository)
        {
            _lenderRepository = lenderRepository;
        }

        public List<Lender> GetList()
        {
            return _lenderRepository.GetAll();
        }
        public Lender GetLender(string id)
        {
            return _lenderRepository.GetById(id);
        }

        public Lender UpdateLender(Lender lender)
        {
            return _lenderRepository.Update(lender);
        }
        public Lender DeleteLender(string id)
        {
            return _lenderRepository.Delete(id);
        }
        public Lender AddLender(Lender lender)
        {
            return _lenderRepository.Add(lender);
        }
    }
}
