using Domain.Entities;
using System.Text.Json.Serialization;

namespace WebAPI.Views
{
    public class TimetableView
    {
        [JsonPropertyName("doctorId")]
        public Doctor Doctor { get; set; }
        [JsonPropertyName("startWorkDay")]
        public DateTime StartWorkDay { get; set; }
        [JsonPropertyName("endWorkDay")]
        public DateTime EndWorkDay { get; set; }
    }
}
