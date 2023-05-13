using System.Linq.Expressions;
using HygieiaApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class Repository<T> : IRepository<T> where T : class
{
    
    private readonly AppDbContext _appDb;
    internal DbSet<T> dbSet;
    public Repository(AppDbContext appDb)
    {
        _appDb = appDb;
        dbSet = _appDb.Set<T>();
    }
    
    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = dbSet;
        return query.ToList();
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filter);

        return query.FirstOrDefault();
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }
    
    
    public void DeleteRange(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
    }
}