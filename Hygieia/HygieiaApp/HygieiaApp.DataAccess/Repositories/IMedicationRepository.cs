using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories;

public interface IMedicationRepository : IRepository<Medication>
{
    void Update(Medication medication);
    void Save();
}