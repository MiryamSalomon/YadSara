
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
        public string BorrowId { get; set; }
        public string BorrowName { get; set;}
        public string Phone { get; set; }
        public string Address { get; set;}
  
        //public int cityId { get; set;}
        public City City { get; set; }

        public List<Lending> Lendings { get; set; }


        //public Borrow(string borrowId, string borrowName, string phone, string address, int cityId)
        //{
        //    this.borrowId = borrowId;
        //    this.borrowName = borrowName;
        //    this.phone = phone;
        //    this.address = address;
        //    this.cityId = cityId;

        //}


    }
}
