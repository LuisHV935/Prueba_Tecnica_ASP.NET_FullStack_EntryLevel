using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Repositories;

// Implementación con EF Core. Cada método es una operación
// atómica: consulta, guarda o elimina contra SQL Server.
public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<ProjectTask>> GetAllAsync()
        => await _context.ProjectTasks.OrderByDescending(t => t.CreatedAt).ToListAsync();

    public async Task<ProjectTask?> GetByIdAsync(int id)
        => await _context.ProjectTasks.FindAsync(id);

    public async Task<ProjectTask> CreateAsync(ProjectTask task)
    {
        _context.ProjectTasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<ProjectTask> UpdateAsync(ProjectTask task)
    {
        _context.ProjectTasks.Update(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task DeleteAsync(int id)
    {
        var task = await _context.ProjectTasks.FindAsync(id);
        if (task != null)
        {
            _context.ProjectTasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
