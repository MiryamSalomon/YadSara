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
    public class LenderRepository: ILenderRepository
    {
        private readonly DataContext _context;

        public LenderRepository(DataContext context)
        {
            _context = context;
        }
        public List<Lender> GetAll()
        {
            return _context.Lender.Include(x=>x.City).ToList();
        }
        public Lender GetById(string id)
        {
            return _context.Lender.ToList().FirstOrDefault(bN => bN.LenderId.Equals(id));
        }
        public Lender Update(Lender lender)
        {
            var index = _context.Lender.ToList().FindIndex(f => f.LenderId == lender.LenderId);
            _context.Lender.ToList()[index].LenderName = lender.LenderName;
            _context.Lender.ToList()[index].LenderId = lender.LenderId;
            _context.Lender.ToList()[index].LenderPhone = lender .LenderPhone;
            _context.Lender.ToList()[index].LenderAdress = lender.LenderAdress;
            _context.Lender.ToList()[index].LenderCityId = lender.LenderCityId;
            _context.SaveChanges();
            return lender;
        }
        public Lender Delete(string id)
        {
            var l = GetById(id);
            _context.Lender.ToList().Remove(l);
            _context.SaveChanges();
            return l;
        }
        public Lender Add(Lender lender)
        {
            _context.Lender.Add(lender);
            _context.SaveChanges();
            return lender;
        }
    }
}
