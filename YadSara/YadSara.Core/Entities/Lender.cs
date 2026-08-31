using System.ComponentModel.DataAnnotations;

namespace YadSara.Core.Entities
{
    //משאיל
    public class Lender
    {
        [Required, StringLength(20)]
        public string lenderId { get; set; }

        [Required, StringLength(100)]
        public string lenderName { get; set; }

        [Required, Phone, StringLength(20)]
        public string lenderPhone { get; set; }

        [Required, StringLength(200)]
        public string lenderAdress { get; set; }

        public int lenderCityId { get; set; }

        public Lender(string lenderId, string lenderName, string lenderPhone, string lenderAdress, int lenderCityId)
        {
            this.lenderId = lenderId;
            this.lenderName = lenderName;
            this.lenderPhone = lenderPhone;
            this.lenderAdress = lenderAdress;
            this.lenderCityId = lenderCityId;
        }
    }
}
