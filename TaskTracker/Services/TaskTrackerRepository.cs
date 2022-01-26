using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Data;
using TaskTracker.Data.Models;

namespace TaskTracker.Services
{
    public class TaskTrackerRepository : ITaskTracker
    {
        private readonly TaskTrackerContext _ctx;

        public TaskTrackerRepository(TaskTrackerContext ctx)
        {
            _ctx = ctx;
        } 

        public void CreateTaskItem(TaskItem taskItem)
        {
            _ctx.Add(taskItem);
            _ctx.SaveChanges();
        }

        public TaskItem GetTaskItem(int taskID)
        {
            var taskToRetrieve = _ctx.TaskItems.Where(t => t.TaskID == taskID).FirstOrDefault();
            return taskToRetrieve; 
        }

        public void UpdateTaskItem(TaskItem taskItem)
        {
            var taskToUpdate = _ctx.TaskItems.Where(t => t.TaskID == taskItem.TaskID).FirstOrDefault();

            taskToUpdate.TaskName = taskItem.TaskName;
            taskToUpdate.TaskDescription = taskItem.TaskDescription;
            taskToUpdate.EstimatedTaskTime = taskItem.EstimatedTaskTime;
            taskToUpdate.DateStarted = taskItem.DateStarted;
            taskToUpdate.DateFinished = taskItem.DateFinished;
            taskToUpdate.Comment = taskItem.Comment;
            _ctx.SaveChanges();
        }

        public void DeleteTaskItem(int taskID)
        {
            var taskToBeDeleted = _ctx.TaskItems.Where(t => t.TaskID == taskID).FirstOrDefault();
            _ctx.TaskItems.Remove(taskToBeDeleted);
            _ctx.SaveChanges();
        }

        public IEnumerable<TaskItem> GetAllTaskItems()
        {
            return _ctx.TaskItems
                    .OrderByDescending(p => p.DateStarted)
                    .ToList();
        }
    }
}
