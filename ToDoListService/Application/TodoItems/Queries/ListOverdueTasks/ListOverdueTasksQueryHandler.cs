using MediatR;
using TodoListApi.Application.Common.Interfaces;
using TodoListApi.Models;

namespace TodoListApi.Application.TodoItems.Queries.ListOverdueTasks
{
    public class ListOverdueTasksQueryHandler : IRequestHandler<ListOverdueTasksQuery, List<ListTasksCallServiceDto>>
    {
        private readonly IListTasksApiHelper _helpers;

        public ListOverdueTasksQueryHandler(IListTasksApiHelper helpers)
        {
            _helpers = helpers;
        }

        public async Task<List<ListTasksCallServiceDto>> Handle(ListOverdueTasksQuery request, CancellationToken cancellationToken)
        {
            return await _helpers.CallListTasksService(false);
        }
    }
}
