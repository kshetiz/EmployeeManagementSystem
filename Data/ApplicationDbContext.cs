using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Entities;
using EmployeeManagementSystem.Models;

namespace EmployeeManagement.Web.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                    .HasOne<Employee>(t => t.Employee)
                    .WithOne(b => b.People)
                    .HasForeignKey<Employee>(t => t.PersonId);

            //modelBuilder.Entity<Positions>()
            //        .HasOne(p => p.Employees)
            //        .WithMany(b => b.Positions);
                    

            //modelBuilder.Entity<EmployeeJobHisstories>()
            //        .HasOne(t => t.Employees)
            //        .WithMany(b => b.EmployeeJobHisstories)
            //        .HasForeignKey(t => t.EmployeeId);


            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();
        }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeJobHistory> EmployeeJobHistorys { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<EmployeeManagementSystem.Models.PositionViewModel>? PositionViewModel { get; set; }
    }
}
