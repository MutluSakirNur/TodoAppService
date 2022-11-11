namespace TodoListApi.Application.TodoItems.Commands.EditTodoTask
{
    public class EditTodoTaskCommandDto
    {
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
