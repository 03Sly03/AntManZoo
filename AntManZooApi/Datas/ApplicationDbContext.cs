using AntManZooClassLibrary.Models;
using AntManZooClassLibrary.Datas;
using Microsoft.EntityFrameworkCore;

namespace AntManZooApi.Datas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(InitialAnimal.animals);
            modelBuilder.Entity<Staff>().HasData(InitialStaff.staffs);
        }

    }
}
