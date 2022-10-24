namespace Domain.Entities
{
    public class Specialization
    {
        public int? Id { get; set; }
        public string? NameOfSpecialization { get; set; }

        public Specialization(string? nameOfSpecialization)
        {
            NameOfSpecialization = nameOfSpecialization;
        }
    }
}
