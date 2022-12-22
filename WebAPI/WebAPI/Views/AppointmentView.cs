using System.Text.Json.Serialization;

namespace WebAPI.Views
{
    public class AppointmentView
    {
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }
        [JsonPropertyName("doctorId")]
        public int DoctorId { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
    }
}
