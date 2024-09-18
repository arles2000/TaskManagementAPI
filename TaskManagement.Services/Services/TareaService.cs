using TaskManagement.Domain.Entities;
using TaskManagement.Repository.Interfaces;
using TaskManagement.Services.Interfaces;

namespace TaskManagement.Services.Services
{
    public class TareaService : ITareaService 
    {
        private readonly ITareaRepository _tareaRepository;

        public TareaService(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        public async Task<IEnumerable<Tarea>> GetAllTareasAsync()
        {
            return await _tareaRepository.GetAllTareasAsync();
        }

        public async Task<Tarea> GetTareaByIdAsync(int id)
        {
            return await _tareaRepository.GetTareaByIdAsync(id);
        }

        public async Task<Tarea> CreateTareaAsync(Tarea tarea)
        {
            return await _tareaRepository.CreateTareaAsync(tarea);
        }

        public async Task<Tarea> UpdateTareaAsync(Tarea tarea)
        {
            return await _tareaRepository.UpdateTareaAsync(tarea);
        }

        public async Task DeleteTareaAsync(int id)
        {
            await _tareaRepository.DeleteTareaAsync(id);
        }
    }
}
