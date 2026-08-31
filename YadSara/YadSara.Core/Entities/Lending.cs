using System.ComponentModel.DataAnnotations;

namespace YadSara.Core.Entities
{
    //השאלות
    public class Lending
    {
        public int LendingId { get; set; }
        public DateTime TimeLending { get; set; }
        public DateTime deadlineLending { get; set; }
        public bool IsReturned { get; set; }
        public int IdEquipment { get; set; }

        [Required, StringLength(20)]
        public string lenderId { get; set; }

        [Required, StringLength(20)]
        public string borrowId { get; set; }

        public Lending(int lendingId, DateTime timeLending, DateTime deadlineLending, bool isReturned, int idEquipment, string lenderId, string borrowId)
        {
            LendingId = lendingId;
            TimeLending = timeLending;
            this.deadlineLending = deadlineLending;
            IsReturned = isReturned;
            IdEquipment = idEquipment;
            this.lenderId = lenderId;
            this.borrowId = borrowId;
        }
    }
}
