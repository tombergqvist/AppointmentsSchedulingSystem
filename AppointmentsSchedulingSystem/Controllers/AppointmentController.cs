using AppointmentsSchedulingSystem.Models;
using AppointmentsSchedulingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsSchedulingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private IExternalAPIService _externalService;
        private IInternalService _internalService;

        public AppointmentController(IExternalAPIService externalService, IInternalService internalService)
        {
            _externalService = externalService;
            _internalService = internalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointment(string name)
        {
            var appointments = await _internalService.GetAppointments(name);
            if (appointments.Any())
                return Ok(appointments);
            else
                return NoContent();
        }

        [HttpPost]
        [Route("Import")]
        public async Task<IActionResult> ImportAppointment()
        {
            var count = await _externalService.ImportAppointments();
            return Ok($"imported: {count}");
        }

        [HttpDelete]
        public IActionResult DeleteAppointment(int id)
        {
            var deleted = _internalService.DeleteAppointment(id);
            return Ok(deleted);
        }

        [HttpPost]
        public IActionResult AddAppointment(AppointmentDTO appointment)
        {
            var message = _internalService.AddAppointment(appointment);
            return Ok(message);
        }

        [HttpPut]
        public IActionResult UpdateAppointment(int id, AppointmentDTO appointment)
        {
            var message = _internalService.UpdateAppointment(id, appointment);
            return Ok(message);
        }
    }
}