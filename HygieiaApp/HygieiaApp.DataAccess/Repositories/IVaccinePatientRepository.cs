using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories;

public interface IVaccinePatientRepository : IRepository<ImmunizationPatient>, ISoftDeleteRepository<ImmunizationPatient>
{
    
}