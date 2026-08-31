using Microsoft.EntityFrameworkCore;
using YadSara.Core.Entities;

namespace YadSara.Data
{
    public class DataContext :DbContext 
    {
        public DbSet<Borrow> Borrow { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Lender> Lender { get; set; }
        public DbSet<Lending> Lending { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=YadSaraM");
        }

        //public DataContext()
        //{
        //    Borrow = new List<Borrow>
        //    {
        //         new Borrow("246987569","yosiLev","0556987459","Rabbi Akiva",1 )
        //    };
        //    City = new List<City>
        //    {
        //        new City(1,"בני ברק" )
        //    };
        //    Equipment = new List<Equipment>
        //    {
        //         new Equipment(1,"מחולל חמצן",5,2,"צק פיקדון","254698745")
        //    };
        //    Lender = new List<Lender>
        //    {
        //    new Lender("254698743","david","0556987459","Rabbi Akiva",1)

        //    };
        //    Lending = new List<Lending>
        //    {
        //    new Lending(1,new DateTime(),new DateTime(),false,1,"26597456","24698756")
        //    };

        //}
    }
}




