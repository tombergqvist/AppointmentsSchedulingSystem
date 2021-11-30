using AppointmentsSchedulingSystem.Mappers;
using AppointmentsSchedulingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppointmentsSchedulingSystem.Services
{
    public class InternalService : IInternalService
    {
        public IContext _context { get; set; }

        public InternalService(IContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments(string name)
        {
            return _context.Appointments.Where(a => a.Name == name || name == null).ToList();
        }

        public bool DeleteAppointment(int id)
        {
            var existing = _context.Appointments.FirstOrDefault(a => a.Id == id);
            if (existing == null)
                return false;
            else
            {
                _context.Appointments.Remove(existing);
                _context.Instance.SaveChanges();
            }
            return true;
        }

        public string UpdateAppointment(int id, AppointmentDTO dto)
        {
            //TODO: Validate the model
            var appointment = _context.Appointments.FirstOrDefault(a => a.Id == id);

            if (appointment == null)
                return $"No appointment with id {id} could be found.";

            var toCompareWith = _context.Appointments.Where(a => a.Name == dto.name && a.Id != id);
            var overlaps = CheckOverlaps(dto, toCompareWith);
            if(overlaps != null)
                return overlaps;

            appointment.UpdateValues(dto);
            _context.Appointments.Update(appointment);
            _context.Instance.SaveChanges();

            return "Sucess!";
        }

        public string AddAppointment(AppointmentDTO dto)
        {
            //TODO: Validate the model
            var toCompareWith = _context.Appointments.Where(a => a.Name == dto.name);
            var overlaps = CheckOverlaps(dto, toCompareWith);
            if (overlaps != null)
                return overlaps;

            _context.Appointments.Add(dto.Convert());
            _context.Instance.SaveChanges();

            return "Sucess!";
        }

        private string CheckOverlaps(AppointmentDTO dto, IEnumerable<Appointment> appointments)
        {
            var existing = appointments.Where(a => a.StartTime == dto.startTime && a.EndTime == dto.endTime);
            if (existing.Any())
            {
                return $"\"SamePeriod\": {JsonSerializer.Serialize(existing)}";
            }

            existing = appointments.Where(a => a.StartTime < dto.endTime && dto.startTime < a.EndTime);
            if (existing.Any())
            {
                return $"\"OverlapsWith\": {JsonSerializer.Serialize(existing)}";
            }
            return null;
        }
    }
}
