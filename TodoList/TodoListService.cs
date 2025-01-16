namespace TodoList;



public class TodoItem(int Id, string Todo, bool Completion)
{
    public int Id { get; set; } = Id;
    public string Todo { get; set; } = Todo;
    public bool Completion { get; set; } = Completion;

}
public class TodoListService
{
    public TodoListService()
    {
        Todos = [];
    }

    public List<TodoItem> Todos ;

    public int AddTodo(string todo)
    {
        var todoItem = new TodoItem(Todos.Count + 1, todo, false);
        Todos.Add(todoItem);
        return todoItem.Id;
    }

    public void RemoveTodo(int id)
    {
        var todoItem = Todos.FirstOrDefault(t => t.Id == id);
        if (todoItem is not null)
        {
            Todos.Remove(todoItem);
        }
    }

    public void UpdateTodo( int id, string todo, bool completion)
    {
        var todoItem = Todos.FirstOrDefault(t => t.Id == id);
        if (todoItem is not null)
        {
            todoItem.Todo = todo;
            todoItem.Completion = completion;
        }

    }

    public void SetComplete(int id, bool completion)
    {
        var todoItem = Todos.FirstOrDefault(t => t.Id == id);
        if (todoItem is not null)
        {
            todoItem.Completion = completion;
        }
    }

    public List<TodoItem> GetTodos( bool completionStatus)
    {
        return Todos.Where(t => t.Completion == completionStatus).ToList();
    }

}
