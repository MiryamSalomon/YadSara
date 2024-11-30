using System.ComponentModel.DataAnnotations;

namespace YadSara.Core.Entities
{
    //ציוד
    public class Equipment
    {
        [Key]
        public int idEquipment { get; set; }
        public string nameEquipment { get; set; }
        public int nameEquipmentck { get; set; }
        public int currentquantity {get; set; }

        public string deposit  { get; set; }

        public string lenderId { get; set; }
        public Equipment(int idEquipment, string nameEquipment, int nameEquipmentck, int currentquantity, string deposit, string lenderId)
        {
            this.idEquipment = idEquipment;
            this.nameEquipment = nameEquipment;
            this.nameEquipmentck = nameEquipmentck;
            this.currentquantity = currentquantity;
            this.deposit = deposit;
            this.lenderId = lenderId;
        }

    }
}
