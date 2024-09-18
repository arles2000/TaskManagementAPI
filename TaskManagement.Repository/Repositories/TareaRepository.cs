using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Repository.Data;
using TaskManagement.Repository.Interfaces;

namespace TaskManagement.Repository.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly AppDbContext _context;

        public TareaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarea>> GetAllTareasAsync()
        {
            return await _context.Tareas.ToListAsync();
        }

        public async Task<Tarea> GetTareaByIdAsync(int id)
        {
            return await _context.Tareas.FindAsync(id);
        }

        public async Task<Tarea> CreateTareaAsync(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return tarea;
        }

        public async Task<Tarea> UpdateTareaAsync(Tarea tarea)
        {
            _context.Entry(tarea).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return tarea;
        }

        public async Task DeleteTareaAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }
    }
}
