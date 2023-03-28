namespace Hygieia.Entities
{
    public class Scheduler
    {
        public int Id { get; set; }
        public string Reminder { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
