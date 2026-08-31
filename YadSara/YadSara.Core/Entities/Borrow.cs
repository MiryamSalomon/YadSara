using System.ComponentModel.DataAnnotations;

namespace YadSara.Core.Entities
{
    // שואל
    public class Borrow
    {
        [Required, StringLength(20)]
        public string borrowId { get; set; }

        [Required, StringLength(100)]
        public string borrowName { get; set; }

        [Required, Phone, StringLength(20)]
        public string phone { get; set; }

        [Required, StringLength(200)]
        public string address { get; set; }

        public int cityId { get; set; }

        public Borrow(string borrowId, string borrowName, string phone, string address, int cityId)
        {
            this.borrowId = borrowId;
            this.borrowName = borrowName;
            this.phone = phone;
            this.address = address;
            this.cityId = cityId;
        }
    }
}
