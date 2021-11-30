using AppointmentsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsAPI.Services
{
    public interface IInternalService
    {
        public Task<IEnumerable<Appointment>> GetAppointments(string name);
        public bool DeleteAppointment(int id);
        public string UpdateAppointment(int id, AppointmentDTO dto);
        public string AddAppointment(AppointmentDTO dto);
    }
}
