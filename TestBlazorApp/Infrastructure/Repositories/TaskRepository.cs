using Microsoft.EntityFrameworkCore;
using TestBlazorApp.Domain.Entities;
using TestBlazorApp.Infrastructure.Data;

namespace TestBlazorApp.Infrastructure.Repositories
{
    public class TaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context) => _context = context;

        public async Task<List<TaskItem>> GetAllAsync() => await _context.Tasks.OrderByDescending(t => t.CreatedAt).ToListAsync();
        public async Task AddAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
                _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
