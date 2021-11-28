using System;
using System.Collections.Generic;

namespace AppointmentsSchedulingSystem.Models
{
    public class AppointmentDTO
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public DateTime date { get; set; }
    }
}
