using FluentAssertions;

namespace TodoList.Tests;

public class TodoListServiceTests
{
    [Fact]
    public void AddTodo_TodoItem_CorrectTodoItem()
    {
        // Arrange 
        var todoListService = new TodoListService();
        var todo = "Test Todo";

        // Act
        var id = todoListService.AddTodo(todo);

        // Assert
        var todoItem = todoListService.Todos.First();
        todoItem.Todo.Should().Be(todo);
        todoItem.Id.Should().Be(id);
        todoItem.Completion.Should().BeFalse();
    }

    [Fact]
    public void RemoveTodo_ExistingId_RemovesTodo()
    {
        // Arrange
        var todoListService = new TodoListService();
        var todo = "Test Todo";
        var id = 1;
        var todoItem = new TodoItem(1, todo, false);
        todoListService.Todos.Add(todoItem);

        // Act
        todoListService.RemoveTodo(id);

        // Assert
        todoListService.Todos.Should().BeEmpty();
        todoListService.Todos.Should().NotContainEquivalentOf(todoItem);
    }

    [Fact]
    public void UpdateTodo_ExistingId_CorrectTodo()
    {
        // Arrange
        var todoListService = new TodoListService();
        var todo = "Test Todo";
        var id = 1;
        todoListService.Todos.Add(new TodoItem(1, todo, false));
        var newTodo = "New Todo";
        var completion = true;

        // Act
        todoListService.UpdateTodo(id, newTodo, completion);

        // Assert
        var todoItem = todoListService.Todos.First();
        todoItem.Todo.Should().Be(newTodo);
        todoItem.Completion.Should().Be(completion);
    }

    [Fact]
    public void SetComplete_ExistingId_CorrectCompletion()
    {
        // Arrange
        var todoListService = new TodoListService();
        var todo = "Test Todo";
        var id = 1;
        todoListService.Todos.Add(new TodoItem(1, todo, false));
        var completion = true;

        // Act
        todoListService.SetComplete(id, completion);

        // Assert
        var todoItem = todoListService.Todos.First();
        todoItem.Completion.Should().Be(completion);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]

    public void GetTodos_CompletionStatus_ReturnsTodos( bool completion)
    {
        // Arrange
        var todoListService = new TodoListService();
        var todo1 = "Test Todo1";
        var todo2= "Test Todo2";
        var todo3 = "Test Todo3";
        todoListService.Todos.Add(new TodoItem(1, todo1, false));
        todoListService.Todos.Add(new TodoItem(2, todo2, false));
        todoListService.Todos.Add(new TodoItem(3, todo3, true));

        // Act
        var todos = todoListService.GetTodos(completion);

        var count = todoListService.Todos.Count(x=>x.Completion != completion);

        // Assert
        todos.Should().ContainEquivalentOf(new TodoItem(1, todo1, false));
        todos.Should().ContainEquivalentOf(new TodoItem(2, todo2, false));
        todos.Should().NotContainEquivalentOf(new TodoItem(3, todo3, true));
    }


}
