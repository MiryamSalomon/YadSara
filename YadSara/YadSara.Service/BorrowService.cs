using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using YadSara.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YadSara.Service
{
    public class BorrowService: IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;
        public BorrowService(IBorrowRepository borrowRepository)
        {
            _borrowRepository = borrowRepository;
        }

        public List<Borrow> GetList()
        {
            return _borrowRepository.GetAll();
        }
        public Borrow GetBorrow(string id)
        {
            return _borrowRepository.GetById(id);
        }

        public Borrow UpdateBorrow(Borrow borrow)
        {
            return _borrowRepository.Update(borrow);
        }
        public void DeleteBorrow(string id)
        {
             _borrowRepository.Delete(id);
        }
        public Borrow AddBorrow(Borrow borrow)
        {
            return _borrowRepository.Add(borrow);
        }

    }
}
