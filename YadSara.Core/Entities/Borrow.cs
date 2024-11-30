
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace YadSara.Core.Entities
{
    // שואל
    public class Borrow
    {

        [Key]
        public string borrowId { get; set; }
        public string borrowName { get; set;}
        public string phone { get; set; }
        public string address { get; set;}
        public int cityId { get; set;}

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
