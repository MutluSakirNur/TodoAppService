using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoListApi.Application.Common.Interfaces;
using TodoListApi.Data;
using TodoListApi.Models;

namespace TodoListApi.Application.TodoItems.Commands.EditTodoTask
{
    public class EditTodoTaskCommandHandler : IRequestHandler<EditTodoTaskCommand, EditTodoTaskCommandDto>
    {
        private readonly ITodoContext _context;

        public EditTodoTaskCommandHandler(ITodoContext context)
        {
            _context = context;
        }

        public async Task<EditTodoTaskCommandDto> Handle(EditTodoTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Title == "")
                {
                    return new EditTodoTaskCommandDto
                    {
                        ErrorMessage = AppConstants.TitleMustntEmpty,
                        IsSuccessful = false
                    };
                }
                else
                {
                    var item = await _context.TodoItems.Where(x => x.Id.Equals(request.Id)).FirstOrDefaultAsync();
                    if (item == null)
                    {
                        return new EditTodoTaskCommandDto()
                        {
                            ErrorMessage = AppConstants.NoItemFound,
                            IsSuccessful = false
                        };
                    }
                    else
                    {
                        item.Title = request.Title;
                        item.DueDate = request.DueDate;
                        item.HasDone = request.HasDone;

                        _context.TodoItems.Update(item);
                        await _context.SaveChangesAsync(cancellationToken);

                        return new EditTodoTaskCommandDto
                        {
                            ErrorMessage = "",
                            IsSuccessful = true
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new EditTodoTaskCommandDto
                {
                    ErrorMessage = ex.Message,
                    IsSuccessful = false
                };

            }
        }
    }
}
