namespace TodoListApi.Models
{
    public class ListTasksCallServiceDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public bool HasDone { get; set; }
    }
}
