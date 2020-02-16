using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerRepository.Tables;

namespace TaskManagerRepository.Interfaces
{
    public interface ITaskRepository
    {
        bool Add(Task task);
        List<Task> GetAll();
        Task GetOneById(int id);
        bool Update(Task task);
        bool RemoveById(int id);
    }
}
