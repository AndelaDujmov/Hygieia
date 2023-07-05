using HygieiaApp.Models.Models;

namespace HygieiaApp.Models.DTO;

public class UserDoctorDto
{
    public ApplicationUser Patient { get; set; }
    public PatientDoctor PatientDoctor { get; set; }
    public ApplicationUser Doctor { get; set; }
    public TestResultsPatient Tests { get; set; }
    public TestResult TestType { get; set; }

    public UserDoctorDto(ApplicationUser user, PatientDoctor patientDoctor, ApplicationUser doctor, TestResultsPatient trp, TestResult tt)
    {
        Patient = user;
        PatientDoctor = patientDoctor;
        Doctor = doctor;
        Tests = trp;
        TestType = tt;
    }
}