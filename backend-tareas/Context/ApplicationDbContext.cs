using backend_tareas.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_tareas.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        //El nombre de la propiedad(Tareas) sera el mismo que el nombre de la bd
        //asi se logra vindear el modelo DbSet<Tarea> con la bd
        public DbSet<Tarea> Tareas { get; set; }

    }
}
