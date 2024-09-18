// TaskService.cs
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

public class TaskService : ITaskService
{
    private readonly HttpClient _httpClient;

    public TaskService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Tarea>> GetTasksByUserIdAsync(int userId)
    {
        return await _httpClient.GetFromJsonAsync<List<Tarea>>($"api/Tarea?userId={userId}");
    }

    public async Task CreateTaskAsync(Tarea task)
    {
        await _httpClient.PostAsJsonAsync("api/Tarea", task);
    }

    public async Task DeleteTaskAsync(int taskId)
    {
        await _httpClient.DeleteAsync($"api/Tarea/{taskId}");
    }
}
