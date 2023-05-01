using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class PatientDoctorRepository : Repository<PatientDoctor>, IPatientDoctorRepository
{
    public PatientDoctorRepository(AppDbContext appDb) : base(appDb)
    {
    }
}