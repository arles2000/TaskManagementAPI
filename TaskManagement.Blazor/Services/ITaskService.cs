// ITaskService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

public interface ITaskService
{
    Task<List<Tarea>> GetTasksByUserIdAsync(int userId);
    Task CreateTaskAsync(Tarea task);
    Task DeleteTaskAsync(int taskId);
}
