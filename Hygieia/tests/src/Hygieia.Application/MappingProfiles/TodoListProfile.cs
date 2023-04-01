using AutoMapper;
using Hygieia.Application.Models.TodoList;
using Hygieia.Core.Entities;


namespace Hygieia.Application.MappingProfiles;

public class TodoListProfile : Profile
{
    public TodoListProfile()
    {
        CreateMap<CreateTodoListModel, TodoList>();

        CreateMap<TodoList, TodoListResponseModel>();
    }
}
