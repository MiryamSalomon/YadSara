using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

            return _context.Borrow.Include(l => l.City).ToList();
        }
        public Borrow GetById(string id)
        {
            return _context.Borrow.ToList().FirstOrDefault(bN => bN.BorrowId == id);
        }
        public Borrow Update(Borrow borrow)
        {
            var index = _context.Borrow.ToList().FindIndex(f => f.BorrowId == borrow.BorrowId);
            _context.Borrow.ToList()[index].BorrowName = borrow.BorrowName;
            _context.Borrow.ToList()[index].Address = borrow.Address;
            _context.Borrow.ToList()[index].Phone = borrow.Phone;
            _context.Borrow.ToList()[index].cityId = borrow.cityId;
            _context.SaveChanges();
            return borrow;
        }
        public Borrow Delete(string id)
        {
            var b = GetById(id);
            _context.Borrow.Remove(b);
            _context.SaveChanges();
            return b;
           
        }
        public Borrow Add(Borrow borrow )
        {
            _context.Borrow.Add(borrow);
            _context.SaveChanges();
            return borrow;
        }

    }
}
