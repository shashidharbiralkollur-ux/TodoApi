using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService
    {
        private readonly List<TodoItem> _todos = new()
        {
            new TodoItem { Id = 1, Title = "Learn Web API", IsDone = false },
            new TodoItem { Id = 2, Title = "Setup Swagger", IsDone = true }
        };

        public IEnumerable<TodoItem> GetAll() => _todos;

        public TodoItem? Get(int id) => _todos.FirstOrDefault(t => t.Id == id);

        public TodoItem Add(string title)
        {
            var todo = new TodoItem
            {
                Id = _todos.Any() ? _todos.Max(t => t.Id) + 1 : 1,
                Title = title,
                IsDone = false
            };
            _todos.Add(todo);
            return todo;
        }

        public bool Update(int id, TodoItem updated)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return false;

            todo.Title = updated.Title;
            todo.IsDone = updated.IsDone;
            return true;
        }

        public bool Delete(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return false;

            _todos.Remove(todo);
            return true;
        }
    }
}
