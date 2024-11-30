using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadSara.Data.Repositories
{
    public class CityRepository: ICityRepository
    {
        private readonly DataContext _context;

        public CityRepository(DataContext context)
        {
            _context = context;
        }
        public List<City> GetAll()
        {
            return _context.City.ToList();
        }
        public City GetById(int id)
        {
            return _context.City.FirstOrDefault(bN => bN.CityId.Equals(id));
        }
        public City Update(City c)
        {
            var index = _context.City.ToList().FindIndex(f => f.CityId == c.CityId);
            _context.City.ToList()[index].CityName = c.CityName;
            _context.City.ToList()[index].CityId = c.CityId;
            return c;
        }
        public void Delete(int id)
        {
            var index = _context.City.ToList().FindIndex(f => f.CityId.Equals( id));
            _context.City.ToList().RemoveAt(index);
        }
        public City Add(City city)
        {
            _context.City.Add(city);
            return city;
        }

    }
}
