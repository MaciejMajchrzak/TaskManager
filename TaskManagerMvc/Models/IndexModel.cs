using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerRepository.Interfaces;
using TaskManagerRepository.Tables;

namespace TaskManagerMvc.Models
{
    public class IndexModel
    {
        public List<Task> tasks { get; set; }

        public void Init(ITaskRepository taskRepository)
        {
            tasks = taskRepository.GetAll();
        }
    }
}
