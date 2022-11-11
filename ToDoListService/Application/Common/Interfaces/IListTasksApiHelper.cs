using TodoListApi.Models;

namespace TodoListApi.Application.Common.Interfaces
{
    public interface IListTasksApiHelper
    {
        Task<List<ListTasksCallServiceDto>> CallListTasksService(bool isPending);
    }
}
