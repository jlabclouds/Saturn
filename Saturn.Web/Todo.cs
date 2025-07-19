namespace Saturn.Web;

public class TodoItem(HttpClient httpClient)
{
    public string? Title { get; set; }
    public bool IsDone { get; set; }
}
