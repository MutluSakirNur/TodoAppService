using MediatR;
using TodoListApi.Models;

namespace TodoListApi.Application.TodoItems.Queries.ListOverdueTasks
{
    public class ListOverdueTasksQuery : IRequest<List<ListTasksCallServiceDto>>
    {
    }
}
