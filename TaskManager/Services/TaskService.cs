using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Services;

// Capa de negocio. Por ahora solo asigna la fecha de
// creación y delega al repositorio. Si en el futuro
// agregamos reglas (estados válidos, auditoría, etc.),
// este es el lugar.
public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository) => _repository = repository;

    public async Task<IEnumerable<ProjectTask>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<ProjectTask?> GetByIdAsync(int id)
        => await _repository.GetByIdAsync(id);

    public async Task<ProjectTask> CreateAsync(ProjectTask task)
    {
        task.CreatedAt = DateTime.UtcNow;
        return await _repository.CreateAsync(task);
    }

    public async Task<ProjectTask> UpdateAsync(ProjectTask task)
        => await _repository.UpdateAsync(task);

    public async Task DeleteAsync(int id)
        => await _repository.DeleteAsync(id);
}
