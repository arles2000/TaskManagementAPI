using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities; // Asegúrate de tener la referencia a las entidades

namespace TaskManagement.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed de Prioridades
            modelBuilder.Entity<Prioridad>().HasData(
                new Prioridad { Id = 1, Nombre = "Alto" },
                new Prioridad { Id = 2, Nombre = "Medio" },
                new Prioridad { Id = 3, Nombre = "Bajo" }
            );
        }
    }
}
