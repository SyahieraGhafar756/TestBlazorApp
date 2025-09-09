﻿using Microsoft.EntityFrameworkCore;
using TestBlazorApp.Domain.Entities;


namespace TestBlazorApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; } = null!;

    }
}
