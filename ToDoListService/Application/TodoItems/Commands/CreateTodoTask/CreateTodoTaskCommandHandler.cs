using MediatR;
using TodoListApi.Application.Common.Interfaces;
using TodoListApi.Data;
using TodoListApi.Models;

namespace TodoListApi.Application.TodoItems.Commands.CreateTodoTask
{
    public class CreateTodoTaskCommandHandler : IRequestHandler<CreateTodoTaskCommand, CreateTodoTaskCommandDto>
    {
        private readonly ITodoContext _context;

        public CreateTodoTaskCommandHandler(ITodoContext context)
        {
            _context = context;
        }

        public async Task<CreateTodoTaskCommandDto> Handle(CreateTodoTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(request.Title == "")
                {
                    return new CreateTodoTaskCommandDto
                    {
                        ErrorMessage = AppConstants.TitleMustntEmpty,
                        IsSuccessful = false
                    };
                }
                else
                {
                    TodoItem? entity = new()
                    {
                        DueDate = request.DueDate,
                        HasDone = false,
                        Title = request.Title
                    };

                    _context.TodoItems.Add(entity);
                    await _context.SaveChangesAsync(cancellationToken);

                    return new CreateTodoTaskCommandDto
                    {
                        ErrorMessage = "",
                        IsSuccessful = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new CreateTodoTaskCommandDto
                {
                    ErrorMessage = ex.Message,
                    IsSuccessful = false,
                };
                
            }
        }
    }
}
