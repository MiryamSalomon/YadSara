using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadSara.Core.Entities;

namespace YadSara.Core.Repositories
{
    public interface ICityRepository
    {
        public List<City> GetAll();
        public City GetById(int id);
        public City Update(City c);
        public void Delete(int id);
        public City Add(City city);

    }
}