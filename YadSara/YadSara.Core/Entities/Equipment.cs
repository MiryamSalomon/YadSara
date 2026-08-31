using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YadSara.Core.Entities
{
    //ציוד
    [Table("Equipment")]
    public class Equipment
    {
        [Key]
        public int idEquipment { get; set; }

        [Required, StringLength(100)]
        public string nameEquipment { get; set; }

        public int nameEquipmentck { get; set; }

        [Range(0, int.MaxValue)]
        public int currentquantity { get; set; }

        [Required, StringLength(100)]
        public string deposit { get; set; }

        [Required, StringLength(20)]
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
