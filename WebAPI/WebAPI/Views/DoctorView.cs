using Domain.Entities;
using System.Text.Json.Serialization;

namespace WebAPI.Views
{
    public class DoctorView
    {
        [JsonPropertyName("id")]
        public int DoctorId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("specialization")]
        public Specialization Specialization { get; set; }
    }
}
