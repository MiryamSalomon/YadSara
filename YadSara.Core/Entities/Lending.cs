using System.ComponentModel.DataAnnotations;

namespace YadSara.Core.Entities
{
    //השאלות 
    public class Lending
    {
        [Key]
        public int LendingId { get; set; }
        public DateTime TimeLending { get; set;}
        public DateTime deadlineLending { get; set; }
        public bool IsReturned { get; set; }
        public int IdEquipment { get; set; }
        public string lenderId { get; set; }
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
