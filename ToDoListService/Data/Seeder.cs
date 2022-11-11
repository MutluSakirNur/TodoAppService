using AutoFixture;

namespace TodoListApi.Data
{
    public static class Seeder
    {
        public static void Seed(this TodoContext todoContext)
        {
            if (todoContext.TodoItems == null || !todoContext.TodoItems.Any())
            {
                Fixture fixture = new Fixture();
                fixture.Customize<TodoItem>(item => item.Without(p => p.Id));
                List<TodoItem> todoItems = fixture.CreateMany<TodoItem>(20).ToList();
                todoContext.AddRange(todoItems);
                todoContext.SaveChanges();
            }
        }
    }
}
