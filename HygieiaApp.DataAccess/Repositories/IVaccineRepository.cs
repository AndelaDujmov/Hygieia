using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories;

public interface IVaccineRepository : IRepository<Immunization>
{
    void Update(Immunization immunization);
    void Save();
}