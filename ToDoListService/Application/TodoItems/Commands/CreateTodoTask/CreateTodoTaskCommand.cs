using MediatR;
using Newtonsoft.Json;

namespace TodoListApi.Application.TodoItems.Commands.CreateTodoTask
{
    /// <summary>
    /// Initializes a new instance of the CreateTodoTaskCommand class.
    /// </summary>
    /// <param name="title">Gets or sets the Title.</param>
    /// <param name="dueDate">Gets or sets the DueDate.</param>
    public class CreateTodoTaskCommand : IRequest<CreateTodoTaskCommandDto>
    {
        public CreateTodoTaskCommand(string title, DateTime? dueDate)
        {
            Title = title;
            DueDate = dueDate?.ToLocalTime();
        }

        ///// <summary>
        ///// An initialization method that performs custom operations like setting defaults
        ///// </summary>

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the DueDate.
        /// </summary>
        [JsonProperty(PropertyName = "dueDate")]
        public DateTime? DueDate { get; set; }
    }
}
