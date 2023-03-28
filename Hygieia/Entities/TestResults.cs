namespace Hygieia.Entities
{
    public class TestResults
    { 
        public int Id { get; set; }
        public string Type { get; set; }
        public DateOnly DateOfTesting { get; set; }
        public string Results { get; set; } // path to pdf document
        public int PatientId { get; set; }
        public User Patient { get; set; } //provjera je li rolename patient
        public bool Deleted { get; set; }
    }
}
