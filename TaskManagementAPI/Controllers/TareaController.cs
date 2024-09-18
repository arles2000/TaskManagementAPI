using TaskManagement.Domain.Entities;
using TaskManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareaController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        // GET: api/Tarea
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetAllTareas()
        {
            var tareas = await _tareaService.GetAllTareasAsync();
            return Ok(tareas);
        }

        // GET: api/Tarea/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTareaById(int id)
        {
            var tarea = await _tareaService.GetTareaByIdAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }
            return Ok(tarea);
        }

        // POST: api/Tarea
        [HttpPost]
        public async Task<ActionResult<Tarea>> CreateTarea(Tarea tarea)
        {
            var createdTarea = await _tareaService.CreateTareaAsync(tarea);
            return CreatedAtAction(nameof(GetTareaById), new { id = createdTarea.Id }, createdTarea);
        }

        // PUT: api/Tarea/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarea(int id, Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return BadRequest("El ID de la tarea no coincide.");
            }

            await _tareaService.UpdateTareaAsync(tarea);
            return NoContent();
        }

        // DELETE: api/Tarea/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            await _tareaService.DeleteTareaAsync(id);
            return NoContent();
        }
    }
}
