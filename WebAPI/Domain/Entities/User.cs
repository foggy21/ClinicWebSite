namespace Domain.Entities
{
    class User
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Role Role { get; }
        
    }
}
