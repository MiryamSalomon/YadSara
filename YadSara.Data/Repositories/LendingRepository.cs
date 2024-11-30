using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadSara.Data.Repositories
{
    public class LendingRepository : ILendingRepository
    {
        private readonly DataContext _context;

        public LendingRepository(DataContext context)
        {
            _context = context;
        }
        public List<Lending> GetAll()
        {
            return _context.Lending.ToList();
        }
        public List<Lending> GetByTime(DateTime time)
        {
          return  _context.Lending.ToList().FindAll(bN => bN.TimeLending.Equals(time));
        }
        public Lending GetById(int id)
        {
            return _context.Lending.ToList().FirstOrDefault(bN => bN.LendingId.Equals(id));
        }
        public List<Lending> GetByLandB(string borrowId, string lenderId)
        {
            return _context.Lending.ToList().FindAll(li => li.borrowId == borrowId && li.lenderId == lenderId);
        }
        public Lending Update(Lending lending)
        {
            var index = _context.Lending.ToList().FindIndex(f => f.LendingId == lending.LendingId);
            _context.Lending.ToList()[index].TimeLending = lending.TimeLending;
            _context.Lending.ToList()[index].deadlineLending = lending.deadlineLending;
            _context.Lending.ToList()[index].IsReturned = lending.IsReturned;
            _context.Lending.ToList()[index].IdEquipment = lending.IdEquipment;
            _context.Lending.ToList()[index].lenderId = lending.lenderId;
            _context.Lending.ToList()[index].borrowId = lending.borrowId;
            return lending;
        }
        public void Delete(int id)
        {
            var index = _context.Lending.ToList().FindIndex(f => f.LendingId.Equals(id));
            _context.Lending.ToList().RemoveAt(index);
        }
        public Lending Add(Lending lending)
        {
            _context.Lending.Add(lending);
            return lending;
        }

    }
}