using AppointmentsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tests.MockModels
{
    public class Context : DbContext, IContext
    {
        public DbContext Instance => this;

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Appointment>().HasKey(a => a.Id);
            modelBuilder.Entity<Appointment>().Property(a => a.Id).ValueGeneratedOnAdd();
        }
    }
}