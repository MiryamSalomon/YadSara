using System.ComponentModel.DataAnnotations;

namespace YadSara.Core.Entities
{
    //משאיל
    public class Lender
    {
        [Key]
        public string LenderId { get; set; }
        public string LenderName { get; set; }

        
       public string LenderPhone { get; set;}
        public string LenderAdress { get; set; }
        public int LenderCityId { get; set;}
        public City City { get; set;}
        public List<Equipment> Equipment { get; set; }
        public List<Lending> Lendings { get; set; }

        //public Lender(string lenderId, string lenderName, string lenderPhone, string lenderAdress, int lenderCityId)
        //{
        //    this.lenderId = lenderId;
        //    this.lenderName = lenderName;
        //    this.lenderPhone = lenderPhone;
        //    this.lenderAdress = lenderAdress;
        //    this.lenderCityId = lenderCityId;
        //}


    }
}
