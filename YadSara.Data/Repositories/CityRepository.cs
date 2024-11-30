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
        
        public City Add(City city)
        {
            _context.City.Add(city);
            return city;
        }

    }
}
