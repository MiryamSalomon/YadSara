using System.ComponentModel.DataAnnotations;

namespace YadSara.Core.Entities
{
    //ציוד
    public class Equipment
    {
        [Key]
        public int IdEquipment { get; set; }
        public string NameEquipment { get; set; }
        public int NameEquipmentck { get; set; }
        public int Currentquantity {get; set; }

        public string Deposit  { get; set; }

        public string LenderId { get; set; }
        public Lender Lender { get; set; }
        //public Equipment(int idEquipment, string nameEquipment, int nameEquipmentck, int currentquantity, string deposit, string lenderId)
        //{
        //    this.idEquipment = idEquipment;
        //    this.nameEquipment = nameEquipment;
        //    this.nameEquipmentck = nameEquipmentck;
        //    this.currentquantity = currentquantity;
        //    this.deposit = deposit;
        //    this.lenderId = lenderId;
        //}

    }
}
