using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities
{
    public class Tarea
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        public DateTime FechaVencimiento { get; set; }
        public bool Finalizado { get; set; }
        public bool Eliminado { get; set; }

        [StringLength(100)]
        public string Tags { get; set; }

        public int IdPrioridad { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
