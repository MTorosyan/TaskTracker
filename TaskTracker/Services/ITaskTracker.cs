using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Data.Models;

namespace TaskTracker.Services
{
    public interface ITaskTracker
    {
        void CreateTaskItem(TaskItem taskItem);
        TaskItem GetTaskItem(int taskID);
        void UpdateTaskItem(TaskItem taskItem);
        void DeleteTaskItem(int taskID);
        IEnumerable<TaskItem> GetAllTaskItems();
            

    }
}
