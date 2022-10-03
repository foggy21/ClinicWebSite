namespace Domain.Entities
{
    class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Specialization Specialization { get; }
    }
}
