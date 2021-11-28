using AppointmentsSchedulingSystem.Mappers;
using AppointmentsSchedulingSystem.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppointmentsSchedulingSystem.Services
{
    public class ExternalAPIService : IExternalAPIService
    {
        public string _API { get; set; }
        public string _key { get; set; }
        public IContext _context { get; set; }

        public ExternalAPIService(IConfiguration config, IContext context)
        {
            _API = config.GetSection("External")["API"];
            _key = config.GetSection("External")["Key"];
            _context = context;
        }

        public async Task<int> ImportAppointments()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("key", _key);
            var response = await client.GetStringAsync($"{_API}");
            var appointmentsDTO = JsonSerializer.Deserialize <IEnumerable<AppointmentDTO>>(response);

            foreach(var appointmentDTO in appointmentsDTO)
            {
                var appointment = appointmentDTO.Convert();

                var existing = _context.Appointments.FirstOrDefault(a => a.Name == appointment.Name 
                && a.StartTime == appointment.StartTime 
                && a.EndTime == appointment.EndTime 
                && a.Date == a.Date);

                if (existing == null)
                    _context.Appointments.Add(appointment);
            }
            return await _context.Instance.SaveChangesAsync();
        }
    }
}
