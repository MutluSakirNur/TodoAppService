using Microsoft.EntityFrameworkCore;
using TodoListApi.Data;

namespace TodoListApi.Application.Common.Interfaces
{
    public interface ITodoContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
