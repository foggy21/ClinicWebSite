namespace Domain.Entities
{
    public class User
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }

        public User(string name, string phone, Role role)
        {
            Name = name;
            Phone = phone;
            Role = role;
        }
        public User(string name, string password, string phone, Role role)
        {
            Name = name;
            Password = password;
            Phone = phone;
            Role = role;
        }
    }
}
