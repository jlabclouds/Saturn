namespace Saturn.Web;

public class TodoItemClient(HttpClient httpClient)
{
    public async Task<TodoItemClient[]> GetTodosAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<TodoItemClient>? todos = null;
        await foreach (var todo in httpClient.GetFromJsonAsAsyncEnumerable<TodoItemClient>("/todo", cancellationToken))
        {
            if (todos?.Count >= maxItems)
            {
                break;
            }
            if (todo is not null)
            {
                todos ??= [];
                todos.Add(todo);
            }
        }
        return todos?.ToArray() ?? [];
    }
}