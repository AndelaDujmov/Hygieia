namespace Hygieia.Entities
{
    public class Scheduler
    {
        public int Id { get; set; }
        public string Reminder { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public int DoctorId { get; set; }
        public User Doctor { get; set; } // provjera je li rolename doctor
        public int PatientId { get; set; }
        public User Patient { get; set; } // provjera je li rolename patient
    }
}
