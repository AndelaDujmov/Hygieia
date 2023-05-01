using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class EventRepository : Repository<Scheduler>, IEventRepository
{
    public EventRepository(AppDbContext appDb) : base(appDb)
    {
    }
}