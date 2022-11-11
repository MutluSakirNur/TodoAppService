using MediatR;
using Newtonsoft.Json;

namespace TodoListApi.Application.TodoItems.Commands.EditTodoTask
{
    /// <summary>
    /// Initializes a new instance of the EditTodoTaskCommand class.
    /// </summary>
    /// <param name="id">Gets or sets the Id</param>
    /// <param name="title">Gets or sets the Title.</param>
    /// <param name="dueDate">Gets or sets the DueDate.</param>
    /// <param name="hasDone">Gets or sets the HasDone</param>
    public class EditTodoTaskCommand : IRequest<EditTodoTaskCommandDto>
    {
        public EditTodoTaskCommand(int id, string title, DateTime? dueDate, bool hasDone)
        {
            Id = id;
            Title = title;
            DueDate = dueDate?.ToLocalTime();
            HasDone = hasDone;
        }

        ///// <summary>
        ///// An initialization method that performs custom operations like setting defaults
        ///// </summary>

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

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

        /// <summary>
        /// Gets or sets the HasDone.
        /// </summary>
        [JsonProperty(PropertyName = "hasDone")]
        public bool HasDone { get; set; }
    }
}
