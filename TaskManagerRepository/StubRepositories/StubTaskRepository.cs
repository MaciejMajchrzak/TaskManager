using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerRepository.Interfaces;
using TaskManagerRepository.Tables;

namespace TaskManagerRepository.StubRepositories
{
    public class StubTaskRepository: ITaskRepository
    {
        public bool Add(Task task)
        {
            return true;
        }
        public List<Task> GetAll()
        {
            List<Task> tasks = new List<Task>();

            Task task = new Task()
            {
                Id = 1,
                Description = "Gym",
                Start = DateTime.Now,
                End = DateTime.Now,
                AllDay = false,
                Important = false
            };

            tasks.Add(task);

            task = new Task()
            {
                Id = 2,
                Description = "Homework",
                Start = DateTime.Now,
                End = null,
                AllDay = true,
                Important = false
            };

            tasks.Add(task);

            task = new Task()
            {
                Id = 3,
                Description = "Work",
                Start = DateTime.Now,
                End = DateTime.Now,
                AllDay = false,
                Important = true
            };

            tasks.Add(task);

            return tasks;
        }
        public Task GetOneById(int id)
        {
            Task task = new Task()
            {
                Id = 1,
                Description = "Gym",
                Start = DateTime.Now,
                End = DateTime.Now,
                AllDay = false,
                Important = false
            };

            return task;
        }
        public bool Update(Task task)
        {
            return true;
        }
        public bool RemoveById(int id)
        {
            return true;
        }
    }
}
