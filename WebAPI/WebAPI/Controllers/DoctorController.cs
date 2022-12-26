using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Implementations;
using WebAPI.Views;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("Doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("FindDoctor")]
        public ActionResult<DoctorView> FindDoctorById (int id)
        {
            var doctor = _doctorService.GetDoctorById(id);
            if(doctor.StatusCode != Domain.Entities.StatusCode.OK)
            {
                return Problem(statusCode: (int)doctor.StatusCode, detail: "Doctor is not found.");
            }

            DoctorView doctorView = new DoctorView
            {
                DoctorId = id,
                Name = doctor.Value.Name,
                Specialization = doctor.Value.Specialization
            };
            return Ok(doctorView);
        }

        [HttpGet("FindAllDoctors")]
        public ActionResult<List<DoctorView>> FindDoctors()
        {
            var listOfDoctors = _doctorService.GetDoctors();
            List<DoctorView> doctors = new List<DoctorView>();
            foreach (var doc in listOfDoctors.Value)
            {
                var docView = new DoctorView
                {
                    DoctorId = doc.Id,
                    Name = doc.Name,
                    Specialization = doc.Specialization
                };
                doctors.Add(docView);
            }
            if (doctors.Count == 0) return Problem(statusCode: 404, detail: "Doctors aren't found.");
            return Ok(doctors);
        }

        [HttpPost("DeleteDoctor")]
        public ActionResult<bool> DeleteDoctor(Doctor doctor)
        {
            var doc = _doctorService.GetDoctorById(doctor.Id);
            if(doc.StatusCode != Domain.Entities.StatusCode.OK)
            {
                return Problem(statusCode: (int)doc.StatusCode, detail: "Doctor isn't found.");
            }
            var deleteResult = _doctorService.DeleteDoctor(doctor);
            return Ok(deleteResult.Value);
        }

        [HttpPost("CreateDoctor")]
        public ActionResult<DoctorView> CreateDoctor(DoctorView doctor)
        {
            if (doctor.Name == string.Empty) return Problem(statusCode: 404, detail: "Name is empty");
            if (doctor.Specialization.Id == -1) return Problem(statusCode: 404, detail: "Specialization id is empty");
            Doctor doc = new Doctor(doctor.Name, doctor.Specialization);
            return Ok(doc);
        }
    }
}
