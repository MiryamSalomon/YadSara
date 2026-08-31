using Microsoft.EntityFrameworkCore;
using YadSara.Core.Entities;

namespace YadSara.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Borrow> Borrow { get; set; } = null!;
        public DbSet<City> City { get; set; } = null!;
        public DbSet<Equipment> Equipment { get; set; } = null!;
        public DbSet<Lender> Lender { get; set; } = null!;
        public DbSet<Lending> Lending { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrow>().HasKey(b => b.borrowId);
            modelBuilder.Entity<City>().HasKey(c => c.CityId);
            modelBuilder.Entity<City>().Property(c => c.CityId).ValueGeneratedNever();
            modelBuilder.Entity<Equipment>().HasKey(e => e.idEquipment);
            modelBuilder.Entity<Equipment>().Property(e => e.idEquipment).ValueGeneratedNever();
            modelBuilder.Entity<Lender>().HasKey(l => l.lenderId);
            modelBuilder.Entity<Lending>().HasKey(l => l.LendingId);
            modelBuilder.Entity<Lending>().Property(l => l.LendingId).ValueGeneratedNever();

            modelBuilder.Entity<Borrow>().HasData(
                new Borrow("246987569", "yosiLev", "0556987459", "Rabbi Akiva", 1));
            modelBuilder.Entity<City>().HasData(
                new City(1, "בני ברק"));
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment(1, "מחולל חמצן", 5, 2, "צק פיקדון", "254698743"));
            modelBuilder.Entity<Lender>().HasData(
                new Lender("254698743", "david", "0556987459", "Rabbi Akiva", 1));
            modelBuilder.Entity<Lending>().HasData(
                new Lending(1, new DateTime(2026, 1, 1), new DateTime(2026, 2, 1), false, 1, "254698743", "246987569"));
        }
    }
}
