using Domain.Entities;
using System.Text.Json.Serialization;

namespace WebAPI.Views
{
    public class UserView
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")] 
        public string Name { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("role")]
        public Role Role { get; set; }
    }
}
