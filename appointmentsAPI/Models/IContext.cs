using Microsoft.EntityFrameworkCore;
using System;

namespace AppointmentsSchedulingSystem.Models
{
    public interface IContext : IDisposable
    {
        DbContext Instance { get; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}