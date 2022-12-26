namespace Domain.DAL
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public  SpecializationModel? specialization { get; set; }
    }
}
