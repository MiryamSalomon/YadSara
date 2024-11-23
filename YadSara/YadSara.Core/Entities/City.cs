namespace YadSara.Core.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public City(int cityId, string cityName)
        {
            CityId = cityId;
            CityName = cityName;
        }
    }
}
