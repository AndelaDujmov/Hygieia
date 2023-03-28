namespace Hygieia.Entities;

public class PatientDoctor
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public User Doctor { get; set; } // provjera ako je rolename = "doctor"
    public User Patient { get; set; } // provjera ako je rolename = "patient"
}