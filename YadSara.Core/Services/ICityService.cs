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
        public City AddCity(City city);

    }
}
