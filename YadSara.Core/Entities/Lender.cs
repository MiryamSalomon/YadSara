using System.ComponentModel.DataAnnotations;

namespace YadSara.Core.Entities
{
    //משאיל
    public class Lender
    {
        [Key]
        public string lenderId { get; set; }
        public string lenderName { get; set; }

        
       public string lenderPhone { get; set;}
        public string lenderAdress{ get; set;}
        public int lenderCityId { get; set;}

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
