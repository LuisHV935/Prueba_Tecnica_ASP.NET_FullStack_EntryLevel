using TaskManager.Models;

namespace TaskManager.Repositories;

// Contrato del repositorio. Define las operaciones de acceso
// a datos sin exponer EF Core al resto de la aplicación.
public interface ITaskRepository
{
    Task<IEnumerable<ProjectTask>> GetAllAsync();
    Task<ProjectTask?> GetByIdAsync(int id);
    Task<ProjectTask> CreateAsync(ProjectTask task);
    Task<ProjectTask> UpdateAsync(ProjectTask task);
    Task DeleteAsync(int id);
}
