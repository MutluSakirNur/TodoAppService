using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoListApi.Application.Common.Interfaces;
using TodoListApi.Application.TodoItems.Commands.CreateTodoTask;
using TodoListApi.Application.TodoItems.Commands.EditTodoTask;
using TodoListApi.Application.TodoItems.Queries.ListOverdueTasks;
using TodoListApi.Application.TodoItems.Queries.ListPendingTasks;
using TodoListApi.Models;

namespace TodoListApi.Controllers
{
    public class TodoItemController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateTodoTask([FromBody] CreateTodoTaskCommand request)
        {
            CreateTodoTaskCommandDto? result = await Mediator.Send(request);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ListPendingTasks()
        {
            ListPendingTasksQuery? query = new() { };

            List<ListTasksCallServiceDto>? result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ListOverdueTasks()
        {
            ListOverdueTasksQuery? query = new() { };

            List<ListTasksCallServiceDto>? result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditTodoTask([FromBody] EditTodoTaskCommand request)
        {
            EditTodoTaskCommandDto? result = await Mediator.Send(request);

            return Ok(result);
        }
    }
}
