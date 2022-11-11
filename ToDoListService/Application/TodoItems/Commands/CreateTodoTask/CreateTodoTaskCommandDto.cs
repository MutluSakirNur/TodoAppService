namespace TodoListApi.Application.TodoItems.Commands.CreateTodoTask
{
    public class CreateTodoTaskCommandDto
    {
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
