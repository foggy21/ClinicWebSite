namespace Domain.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Specialization? Specialization { get; set; }

        public Doctor(string? name, Specialization specialization)
        {
            Name = name;
            Specialization = specialization;
        }
    }
}
