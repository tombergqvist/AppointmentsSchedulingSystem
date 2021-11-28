using AppointmentsSchedulingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsSchedulingSystem.Mappers
{
    public static class AppointmentMapper
    {
        public static Appointment Convert(this AppointmentDTO appointment)
        {
            return new Appointment()
            {
                Name = appointment.name,
                PhoneNumber = appointment.phoneNumber,
                Email = appointment.email,
                StartTime = appointment.startTime,
                EndTime = appointment.endTime,
                Date = appointment.date
            };
        }

        public static void UpdateValues(this Appointment appointment, AppointmentDTO dto)
        {
            appointment.Name = dto.name;
            appointment.PhoneNumber = dto.phoneNumber;
            appointment.Email = dto.email;
            appointment.StartTime = dto.startTime;
            appointment.EndTime = dto.endTime;
            appointment.Date = dto.date;
        }
    }
}
