namespace TodoListApi.Data
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public DateTime? DueDate { get; set; }
        public bool HasDone { get; set; }
    }
}
