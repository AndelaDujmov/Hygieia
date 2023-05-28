using HygieiaApp.Models.Models;

namespace HygieiaApp.Models.DTO;

public class UserDoctorDto
{
    public User Patient { get; set; }
    public PatientDoctor PatientDoctor { get; set; }
    public User Doctor { get; set; }
    public TestResultsPatient Tests { get; set; }
    public TestResult TestType { get; set; }

    public UserDoctorDto(User user, PatientDoctor patientDoctor, User doctor, TestResultsPatient trp, TestResult tt)
    {
        Patient = user;
        PatientDoctor = patientDoctor;
        Doctor = doctor;
        Tests = trp;
        TestType = tt;
    }
}