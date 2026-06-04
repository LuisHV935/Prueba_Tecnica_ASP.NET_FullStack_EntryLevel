using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.ViewModels;

namespace TaskManager.Controllers;

// Controlador CRUD. Usa el servicio para toda operación.
// El controlador no conoce EF Core ni el repositorio,
// solo trabaja con ViewModels y modelos de dominio.
public class TasksController : Controller
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService) => _taskService = taskService;

    public async Task<IActionResult> Index()
    {
        var tasks = await _taskService.GetAllAsync();
        return View(tasks);
    }

    public async Task<IActionResult> Details(int id)
    {
        var task = await _taskService.GetByIdAsync(id);
        if (task == null) return NotFound();

        return View(MapToViewModel(task));
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaskViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        var task = new ProjectTask
        {
            Title = viewModel.Title,
            Description = viewModel.Description,
            Status = viewModel.Status
        };

        await _taskService.CreateAsync(task);
        TempData["Success"] = "Tarea creada correctamente.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var task = await _taskService.GetByIdAsync(id);
        if (task == null) return NotFound();

        return View(MapToViewModel(task));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TaskViewModel viewModel)
    {
        if (id != viewModel.Id) return BadRequest();
        if (!ModelState.IsValid) return View(viewModel);

        var task = await _taskService.GetByIdAsync(id);
        if (task == null) return NotFound();

        task.Title = viewModel.Title;
        task.Description = viewModel.Description;
        task.Status = viewModel.Status;

        await _taskService.UpdateAsync(task);
        TempData["Success"] = "Tarea actualizada correctamente.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var task = await _taskService.GetByIdAsync(id);
        if (task == null) return NotFound();

        return View(MapToViewModel(task));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _taskService.DeleteAsync(id);
        TempData["Success"] = "Tarea eliminada correctamente.";
        return RedirectToAction(nameof(Index));
    }

    private static TaskViewModel MapToViewModel(ProjectTask task) => new()
    {
        Id = task.Id,
        Title = task.Title,
        Description = task.Description,
        Status = task.Status,
        CreatedAt = task.CreatedAt
    };
}
