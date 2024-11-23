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
    public class LendingService: ILendingService
    {
        private readonly ILendingRepository _lendingRepository;
        public LendingService(ILendingRepository lendingRepository)
        {
            _lendingRepository = lendingRepository;
        }

        public List<Lending> GetList()
        {
            return _lendingRepository.GetAll();
        }
        public List<Lending> GetListByDate(DateTime date)
        { 
            return _lendingRepository.GetByTime(date);
        }
        public List<Lending> GetListLandB(string borrowId, string lenderId)
        {
            return _lendingRepository.GetByLandB(borrowId, lenderId);
        }
        public Lending GetLending(int id)
        {
            return _lendingRepository.GetById(id);
        }

        public Lending UpdateLending(Lending lending)
        {
            return _lendingRepository.Update(lending);
        }
        public void DeleteLending (int id)
        {
             _lendingRepository.Delete(id);
        }
        public Lending AddLending(Lending lending)
        {
          return  _lendingRepository.Add(lending);
        }
    }
}
