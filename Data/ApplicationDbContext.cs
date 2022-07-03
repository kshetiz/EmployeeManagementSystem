using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Entities;

namespace EmployeeManagement.Web.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().HasOne(t => t.Employees)
                    .WithOne(t => t.People)
                     .HasForeignKey<Employees>(t => t.PersonId);

           
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();
        }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<EmployeeJobHisstories> EmployeeJobHisstories { get; set; }
        public DbSet<Positions> Positions { get; set; }
    }
}
