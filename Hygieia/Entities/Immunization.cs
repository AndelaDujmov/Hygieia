namespace Hygieia.Entities
{
    public class Immunization
    {
        public int Id { get; set; }
        public DateOnly DateOfVaccination { get; set; }
        public string Type { get; set; }
        public int? PatientId { get; set; }
        public User user { get; set; }
    }
}
