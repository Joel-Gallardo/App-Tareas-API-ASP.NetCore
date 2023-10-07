using backend_tareas.Context;
using backend_tareas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TareaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaTareas = await _context.Tareas.ToListAsync();
                return Ok(listaTareas);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            try
            {
                _context.Tareas.Add(tarea);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarea fue registrada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tarea tarea)
        {
            try
            {
                if(id != tarea.Id) 
                {
                    return NotFound();
                }
                tarea.Estado = !tarea.Estado;
                _context.Entry(tarea).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "estado de la tarea actualizado exitosamente" });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarea = await _context.Tareas.FindAsync(id);
                if(tarea == null)
                {
                    return NotFound();
                }
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
                return Ok(new { message = $"Tarea  '{tarea.Nombre}' eliminada exitosamente" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
