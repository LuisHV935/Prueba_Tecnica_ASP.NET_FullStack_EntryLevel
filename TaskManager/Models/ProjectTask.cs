using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;

// Entidad que mapea a la tabla ProjectTasks en SQL Server.
// Las validaciones con Data Annotations se evalúan tanto
// en servidor (ModelState) como en cliente (jQuery Validation).
public class ProjectTask
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    [StringLength(100, ErrorMessage = "El título no puede exceder 100 caracteres.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "El estado es obligatorio.")]
    [StringLength(20)]
    public string Status { get; set; } = "Pending";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
