using Hygieia.Core.Entities;
using Hygieia.DataAccess.Persistence;


namespace Hygieia.DataAccess.Repositories.Impl;

public class TodoListRepository : BaseRepository<TodoList>, ITodoListRepository
{
    public TodoListRepository(DatabaseContext context) : base(context) { }
}
