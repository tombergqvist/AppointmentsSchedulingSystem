using AppointmentsSchedulingSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentsSchedulingSystem.Services
{
    public interface IExternalAPIService
    {
        public Task<int> ImportAppointments();
    }
}