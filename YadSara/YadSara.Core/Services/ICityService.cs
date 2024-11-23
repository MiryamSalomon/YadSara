using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadSara.Core.Entities;

namespace YadSara.Core.Services
{
    public interface ICityService
    {
        public List<City> GetList();
        public City GetCity(int id);
        public City UpdateCity(City c);
        public void DeleteCity(int id);
        public City AddCity(City city);

    }
}
