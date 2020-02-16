using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TaskManagerRepository.Tables;

namespace TaskManagerRepository
{
    public class TaskManagerContext: DbContext
    {
        private readonly string _connectionString;

        public TaskManagerContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_connectionString);
        }

        public virtual DbSet<Task> Tasks { get; set; }
    }
}
