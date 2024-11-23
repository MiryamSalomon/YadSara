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
            return _context.Lending;
        }
        public List<Lending> GetByTime(DateTime time)
        {
          return  _context.Lending.FindAll(bN => bN.TimeLending.Equals(time));
        }
        public Lending GetById(int id)
        {
            return _context.Lending.FirstOrDefault(bN => bN.LendingId.Equals(id));
        }
        public List<Lending> GetByLandB(string borrowId, string lenderId)
        {
            return _context.Lending.FindAll(li => li.borrowId == borrowId && li.lenderId == lenderId);
        }
        public Lending Update(Lending lending)
        {
            var index = _context.Lending.FindIndex(f => f.LendingId == lending.LendingId);
            _context.Lending[index].TimeLending = lending.TimeLending;
            _context.Lending[index].deadlineLending = lending.deadlineLending;
            _context.Lending[index].IsReturned = lending.IsReturned;
            _context.Lending[index].IdEquipment = lending.IdEquipment;
            _context.Lending[index].lenderId = lending.lenderId;
            _context.Lending[index].borrowId = lending.borrowId;
            return lending;
        }
        public void Delete(int id)
        {
            var index = _context.Lending.FindIndex(f => f.LendingId.Equals(id));
            _context.Lending.RemoveAt(index);
        }
        public Lending Add(Lending lending)
        {
            _context.Lending.Add(lending);
            return lending;
        }

    }
}