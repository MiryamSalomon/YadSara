using System.ComponentModel.DataAnnotations;

namespace YadSara.Core.Entities
{
    public class City
    {
        public int CityId { get; set; }

        [Required, StringLength(100)]
        public string CityName { get; set; }

        public City(int cityId, string cityName)
        {
            CityId = cityId;
            CityName = cityName;
        }
    }
}
