using MediatR;
using TodoListApi.Models;

namespace TodoListApi.Application.TodoItems.Queries.ListPendingTasks
{
    public class ListPendingTasksQuery : IRequest<List<ListTasksCallServiceDto>>
    {
    }
}
