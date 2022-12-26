using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Implementations;
using WebAPI.Views;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("Appointment")]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;
        public AppointmentController(AppointmentService service)
        {
            _appointmentService = service;
        }

        [HttpPost("SaveAppointment")]
        public ActionResult<bool> SaveAppointment(Doctor doctor, DateTime end)
        {
            var appointment = _appointmentService.SaveAppointment(doctor, end);
            if (appointment.StatusCode != Domain.Entities.StatusCode.OK) return Problem(statusCode: 404, detail: "Unable to save.");
            return Ok(appointment.Value);
        }

        [HttpPost("SaveAppointmentToAnyDoctor")]
        public ActionResult<bool> SaveAppointmentToAnyDoctor(Specialization specialization, DateTime date)
        {
            Specialization spec = new Specialization(specialization.NameOfSpecialization);
            var appointment = _appointmentService.SaveAppointmentToAnyDoctor(specialization, date);
            if (appointment.StatusCode != Domain.Entities.StatusCode.OK) return Problem(statusCode: 404, detail: "Unable to save.");
                
            return Ok(appointment.Value);
        }

        [HttpGet("GetFreeDatesForSpecialization")]
        public ActionResult<List<DateTime>> GetFreeDatesForSpecialization(Specialization specialization)
        {
            var appointment = _appointmentService.GetFreeDatesForSpecialization(specialization);
            if (appointment.Value.Count == 0) return Problem(statusCode: 404, detail: "Unable to get.");
            return Ok(appointment.Value);
        }
    }
}