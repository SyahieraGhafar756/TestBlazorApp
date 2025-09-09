using TestBlazorApp.Domain.Entities;
using TestBlazorApp.Infrastructure.Repositories;

namespace TestBlazorApp.Application
{
    public class TaskService
    {
        private readonly TaskRepository _repository;
        public TaskService(TaskRepository repository) => _repository = repository;

        public async Task<List<TaskItem>> GetTasksAsync() => await _repository.GetAllAsync();
        public async Task AddTaskAsync(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required");
            await _repository.AddAsync(new TaskItem { Title = title, Description = description });
        }
        public async Task ToggleCompleteAsync(TaskItem task)
        {
            task.IsCompleted = !task.IsCompleted;
            await _repository.UpdateAsync(task);
        }
        public async Task DeleteTaskAsync(int id) => await _repository.DeleteAsync(id);
    }
}
