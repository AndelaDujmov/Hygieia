using Hygieia.Core.Entities;
using Hygieia.DataAccess.Persistence;

namespace Hygieia.DataAccess.Repositories.Impl;

public class TodoItemRepository : BaseRepository<TodoItem>, ITodoItemRepository
{
    public TodoItemRepository(DatabaseContext context) : base(context) { }
}
