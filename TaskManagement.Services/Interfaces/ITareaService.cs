using TaskManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagement.Services.Interfaces
{
    public interface ITareaService
    {
        Task<IEnumerable<Tarea>> GetAllTareasAsync();
        Task<Tarea> GetTareaByIdAsync(int id);
        Task<Tarea> CreateTareaAsync(Tarea tarea);
        Task<Tarea> UpdateTareaAsync(Tarea tarea);
        Task DeleteTareaAsync(int id);
    }
}
