using System.ComponentModel.DataAnnotations;

namespace TaskManager.ViewModels;

// ViewModel para las vistas del CRUD. Tiene las mismas
// propiedades que ProjectTask pero aquí se ponen las
// validaciones de formulario. Separa la capa de presentación
// del modelo de datos.
public class TaskViewModel
{
    public int Id { get; set; }

    [Display(Name = "Título")]
    [Required(ErrorMessage = "El título es obligatorio.")]
    [StringLength(100, ErrorMessage = "El título no puede exceder 100 caracteres.")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Descripción")]
    [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres.")]
    public string? Description { get; set; }

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "El estado es obligatorio.")]
    [StringLength(20)]
    public string Status { get; set; } = "Pending";

    [Display(Name = "Creada")]
    public DateTime CreatedAt { get; set; }
}
