using Microsoft.EntityFrameworkCore;
using TodoListApi.Application.Common.Interfaces;
using TodoListApi.Data;
using TodoListApi.Models;

namespace TodoListApi.Infrastructure.Services
{
    public class ListTasksApiHelper : IListTasksApiHelper
    {
        private readonly ITodoContext _context;
        public ListTasksApiHelper(ITodoContext context)
        {
            _context = context;
        }
        public virtual async Task<List<ListTasksCallServiceDto>> CallListTasksService(bool isPending)
        {
            List<ListTasksCallServiceDto>? getTasks = new();
            List<TodoItem> tasks;
            DateTime currentDate = DateTime.Now.ToLocalTime();
            if (isPending)
            {
                tasks = await _context.TodoItems.Where(w => w.HasDone == false && (w.DueDate >= currentDate || w.DueDate == null)).OrderBy(w => w.DueDate).ToListAsync();
            }
            else
            {
                tasks = await _context.TodoItems.Where(w => w.HasDone == false && w.DueDate < currentDate).OrderByDescending(w => w.DueDate).ToListAsync();
            }
            

            foreach (var item in tasks)
            {
                ListTasksCallServiceDto tempItem = new()
                {
                    Id = item.Id,
                    DueDate = item.DueDate,
                    HasDone = item.HasDone,
                    Title = item.Title
                };
                getTasks.Add(tempItem);
            }

            return getTasks;
        }
    }
}
