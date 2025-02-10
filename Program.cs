
using Microsoft.Extensions.DependencyInjection;
using Refit;


var services = new ServiceCollection();
services
    .AddRefitClient<IJsonPlaceHolderGateway>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com"));

var provider = services.BuildServiceProvider();
var gateway = provider.GetService<IJsonPlaceHolderGateway>();

if (gateway != null)
{
    var taskItem = await gateway.GetTaskItem(3);
    Console.WriteLine($"{taskItem.Id}:  {taskItem.Title}  Complete:  {taskItem.Complete}");
}


public interface IJsonPlaceHolderGateway
{
    [Get("/todos/{id}")]
    Task<TaskItem> GetTaskItem(int id);
}

public class TaskItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool Complete { get; set; }
}