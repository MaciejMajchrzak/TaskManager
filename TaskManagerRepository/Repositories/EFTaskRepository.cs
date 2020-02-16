using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagerRepository.Interfaces;
using TaskManagerRepository.Tables;

namespace TaskManagerRepository.Repositories
{
    public class EFTaskRepository : ITaskRepository
    {
        TaskManagerContext _taskManagerContext;

        public EFTaskRepository(TaskManagerContext taskManagerContext)
        {
            _taskManagerContext = taskManagerContext;
        }

        public bool Add(Task task)
        {
            try
            {
                if (task.AllDay == true)
                {
                    task.End = null;
                }

                if(task.Start > task.End && task.AllDay == false)
                {
                    return false;
                }

                _taskManagerContext.Tasks.Add(task);

                _taskManagerContext.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<Task> GetAll()
        {
            return _taskManagerContext.Tasks.ToList();
        }

        public Task GetOneById(int id)
        {
            return _taskManagerContext.Tasks.FirstOrDefault(p => p.Id == id);
        }

        public bool RemoveById(int id)
        {
            try
            {
                var obj = GetOneById(id);

                _taskManagerContext.Tasks.Remove(obj);

                _taskManagerContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Task task)
        {
            try
            {
                var obj = GetOneById(task.Id);

                obj.Description = task.Description;

                obj.Start = task.Start;

                if(task.AllDay == true)
                {
                    obj.End = null;
                }
                else
                {
                    obj.End = task.End;
                }

                if (obj.Start > obj.End && task.AllDay == false)
                {
                    return false;
                }

                obj.AllDay = task.AllDay;

                obj.Important = task.Important;

                _taskManagerContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _taskManagerContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
