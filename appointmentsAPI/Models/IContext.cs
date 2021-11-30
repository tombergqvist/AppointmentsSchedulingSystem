using Microsoft.EntityFrameworkCore;
using System;

namespace AppointmentsAPI.Models
{
    public interface IContext : IDisposable
    {
        DbContext Instance { get; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}