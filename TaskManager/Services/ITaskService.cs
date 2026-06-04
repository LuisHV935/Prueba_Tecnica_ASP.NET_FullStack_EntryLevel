using TaskManager.Models;

namespace TaskManager.Services;

// Contrato del servicio. Separa la lógica de negocio
// del controlador. Aquí irían reglas como "no crear
// tareas duplicadas" o notificaciones.
public interface ITaskService
{
    Task<IEnumerable<ProjectTask>> GetAllAsync();
    Task<ProjectTask?> GetByIdAsync(int id);
    Task<ProjectTask> CreateAsync(ProjectTask task);
    Task<ProjectTask> UpdateAsync(ProjectTask task);
    Task DeleteAsync(int id);
}
