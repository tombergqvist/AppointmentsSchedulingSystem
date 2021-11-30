using AppointmentsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentsAPI.Services
{
    public interface IExternalAPIService
    {
        public Task<int> ImportAppointments();
    }
}