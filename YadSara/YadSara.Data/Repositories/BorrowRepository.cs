using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YadSara.Data.Repositories
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly DataContext _context;

        public BorrowRepository(DataContext context)
        {
            _context = context;
        }
        public List<Borrow> GetAll()
        {
            return _context.Borrow;
        }
        public Borrow GetById(string id)
        {
            return _context.Borrow.FirstOrDefault(bN => bN.borrowId == id);
        }
        public Borrow Update(Borrow borrow)
        {
            var index = _context.Borrow.FindIndex(f => f.borrowId == borrow.borrowId);
            _context.Borrow[index].borrowName = borrow.borrowName;
            _context.Borrow[index].address = borrow.address;
            _context.Borrow[index].phone = borrow.phone;
            _context.Borrow[index].cityId = borrow.cityId;
            return borrow;
        }
        public void Delete(string id)
        {
            var index = _context.Borrow.FindIndex(f => f.borrowId.Equals( id));
            _context.Borrow.RemoveAt(index);
        }
        public Borrow Add(Borrow borrow )
        {
            _context.Borrow.Add(borrow);
            return borrow;
        }

    }
}
