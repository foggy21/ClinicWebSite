using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Implementations;
using WebAPI.Views;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("Timetable")]
    public class ScheduleController : ControllerBase
    {
        private readonly TimetableService _timetableService;
        public ScheduleController(TimetableService service)
        {
            _timetableService = service;
        }

        [HttpGet("GetTimetableByDate")]
        public ActionResult<List<TimetableView>> GetDoctorScheduleByDate([FromQuery] DoctorView model, [FromQuery] DateOnly date)
        {
            Doctor doc = new Doctor(model.Name, model.Specialization);
            var timetableResult = _timetableService.GetTimeTable(doc, date);
            if (timetableResult.StatusCode != Domain.Entities.StatusCode.OK) return Problem(statusCode: (int)timetableResult.StatusCode, detail: "Timetalbe isn't found.");
            List<TimetableView> listOfTimetable = new List<TimetableView>();
            foreach (var item in timetableResult.Value)
            {
                TimetableView view = new TimetableView
                {
                    Doctor = item.Doctor,
                    StartWorkDay = item.StartWorkDay,
                    EndWorkDay = item.EndWorkDay
                };
                listOfTimetable.Add(view);
            }
            
            return Ok(listOfTimetable);
        }

        [HttpPost("AddTimetable")]
        public ActionResult<bool> AddTimetable(TimetableView model)
        {
            var timetableResult = _timetableService.AddTimeTable(model.Doctor, model.StartWorkDay, model.EndWorkDay);
            if (timetableResult.StatusCode != Domain.Entities.StatusCode.OK) return Problem(statusCode: 404, detail: "Невозможно добавить");
            return Ok(timetableResult.Value);
        }

        [HttpPost("EditTimetable")]
        public ActionResult<TimetableView> EditTimetable(TimetableView model)
        {
            var timetableResult = _timetableService.EditTimeTable(model.Doctor, model.StartWorkDay, model.EndWorkDay);
            if (timetableResult.StatusCode != Domain.Entities.StatusCode.OK) return Problem(statusCode: 404, detail: "Невозможно добавить");
            return Ok(timetableResult.Value);
        }
    }
}
