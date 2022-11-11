using MediatR;
using TodoListApi.Application.Common.Interfaces;
using TodoListApi.Models;

namespace TodoListApi.Application.TodoItems.Queries.ListPendingTasks
{
    public class ListPendingTasksQueryHandler : IRequestHandler<ListPendingTasksQuery, List<ListTasksCallServiceDto>>
    {
        private readonly IListTasksApiHelper _helpers;

        public ListPendingTasksQueryHandler(IListTasksApiHelper helpers)
        {
            _helpers = helpers;
        }

        public async Task<List<ListTasksCallServiceDto>> Handle(ListPendingTasksQuery request, CancellationToken cancellationToken)
        {
            return await _helpers.CallListTasksService(true);
        }
    }
}
