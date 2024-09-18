using System.ComponentModel.DataAnnotations;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Apellido { get; set; }

    [Required]
    [EmailAddress]
    public string Correo { get; set; }

    [Phone]
    public string Telefono { get; set; }

    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
}
