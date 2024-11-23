using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _context.Lender;
        }
        public Lender GetById(string id)
        {
            return _context.Lender.FirstOrDefault(bN => bN.lenderId.Equals(id));
        }
        public Lender Update(Lender lender)
        {
            var index = _context.Lender.FindIndex(f => f.lenderId == lender.lenderId);
            _context.Lender[index].lenderName = lender.lenderName;
            _context.Lender[index].lenderId = lender.lenderId;
            _context.Lender[index].lenderPhone = lender .lenderPhone;
            _context.Lender[index].lenderAdress = lender.lenderAdress;
            _context.Lender[index].lenderCityId = lender.lenderCityId;
            return lender;
        }
        public void Delete(string id)
        {
            var index = _context.Lender.FindIndex(f => f.lenderId.Equals(id));
            _context.Lender.RemoveAt(index);
        }
        public Lender Add(Lender lender)
        {
            _context.Lender.Add(lender);
            return lender;
        }
    }
}
