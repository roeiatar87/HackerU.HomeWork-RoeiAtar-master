using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.HackerU.HomeWork.HW_19
{
    public class ManagingContext : DbContext
    {
        public DbSet<Manager> managers { get; set; }

        public DbSet<Employee> employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HW19_Q2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Employee>()
            //.HasOne(e => e.manager)
            //.WithMany(e => e.employeesList)
            //.HasForeignKey(e => e.ManagerId)
            //.IsRequired();

            modelBuilder.Entity<Employee>()
           .HasMany(e => e.managerss)
           .WithMany(e => e.employeesList);

        }
    }
}
