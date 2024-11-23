using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using YadSara.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadSara.Service
{
    public class CityService: ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public List<City> GetList()
        {
            return _cityRepository.GetAll();
        }
        public City GetCity(int id)
        {
            return _cityRepository.GetById(id);
        }

        public City UpdateCity(City city)
        {
            return _cityRepository.Update(city);
        }
        public void DeleteCity(int id)
        {
             _cityRepository.Delete(id);
        }
        public City AddCity(City city)
        {
            return _cityRepository.Add(city);
        }
    }
}
