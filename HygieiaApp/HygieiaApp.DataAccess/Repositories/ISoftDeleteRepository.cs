namespace HygieiaApp.DataAccess.Repositories;

public interface ISoftDeleteRepository<T> where T:class
{
    IEnumerable<T> GetANonDeleted();
    IEnumerable<T> GetAllDeleted();
    void SoftDelete(Guid id);
    void RetrieveDeleted(Guid id);
}