using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Data.Models;

namespace TaskTracker.Services
{
    public class TaskTrackerService : ITaskTracker
    {
        private List<TaskItem> _taskList;

        public TaskTrackerService()
        {
            _taskList = new List<TaskItem>()
            {
                new TaskItem {TaskID = 1000, TaskName = "Prep for interview", TaskDescription = "Prepare for your interview", EstimatedTaskTime =  7.5, DateStarted =  new DateTime(2018, 7, 14, 8, 0, 0).ToUniversalTime(), DateFinished = new DateTime(2018, 7, 15, 12, 0, 0).ToUniversalTime()}, 
                new TaskItem {TaskID = 1001, TaskName = "Finish tutorial", TaskDescription = "Finish tutorial on pluralsight", EstimatedTaskTime = 22, DateStarted = new DateTime(2018, 7, 8, 9, 0, 0).ToUniversalTime(), DateFinished = new DateTime(2018, 7, 14, 12, 0, 0).ToUniversalTime() },
                new TaskItem {TaskID = 1002, TaskName = "C# Tutorials", TaskDescription = "Finish Udemy tutorials on C#", EstimatedTaskTime = 33, DateStarted = new DateTime(2018, 6, 1, 8, 0, 0).ToUniversalTime(), DateFinished = new DateTime(2018, 7, 2, 12, 0, 0).ToUniversalTime()}
            };
        }

        public void CreateTaskItem(TaskItem taskItem)
        {
            taskItem.TaskID = 4000;
            _taskList.Add(taskItem);
        }

        public void DeleteTaskItem(int taskID)
        {
            var taskToBeDeleted = _taskList.Where(t => t.TaskID == taskID).FirstOrDefault();
            _taskList.Remove(taskToBeDeleted);
        }

        public IEnumerable<TaskItem> GetAllTaskItems()
        {
            return _taskList;
        }

        public TaskItem GetTaskItem(int taskID)
        {
            var taskToRetrieve = _taskList.Where(t => t.TaskID == taskID).FirstOrDefault();
            return taskToRetrieve;
        }

        public void UpdateTaskItem(TaskItem taskItem)
        {
            var taskToUpdate = _taskList.Where(t => t.TaskID == taskItem.TaskID).FirstOrDefault();

            taskToUpdate.TaskName = taskItem.TaskName;
            taskToUpdate.TaskDescription = taskItem.TaskDescription;
            taskToUpdate.EstimatedTaskTime = taskItem.EstimatedTaskTime;
            taskToUpdate.DateStarted = taskItem.DateStarted;
            taskToUpdate.DateFinished = taskItem.DateFinished;
            taskToUpdate.Comment = taskItem.Comment;

            var timespent = taskToUpdate.DateFinished - taskToUpdate.DateStarted;
        }
    }
}
