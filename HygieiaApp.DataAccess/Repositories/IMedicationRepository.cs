using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories;

public interface IMedicationRepository : IRepository<Medication>, ISoftDeleteRepository<Medication>
{
    void Update(Medication medication);
}