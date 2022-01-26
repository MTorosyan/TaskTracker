using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Data.Models;

namespace TaskTracker.Data
{
    public class TaskTrackerSeeder
    {
        private readonly TaskTrackerContext _ctx;
        private IEnumerable<TaskItem> _task;
        
        public TaskTrackerSeeder(TaskTrackerContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.TaskItems.Any())
            {
                //Need to create sample data
                 
                _task = new List<TaskItem>() {new TaskItem { TaskName = "Prep for interview", TaskDescription = "Prepare for your interview", EstimatedTaskTime = 7.5, DateStarted = new DateTime(2018, 7, 14, 8, 0, 0).ToUniversalTime(), DateFinished = new DateTime(2021, 11, 15, 12, 0, 0).ToUniversalTime() },
                 new TaskItem { TaskName = "Pick up dog", TaskDescription = "Pick up dog from groomers", EstimatedTaskTime = 0.5, DateStarted = new DateTime(2018, 7, 8, 9, 0, 0).ToUniversalTime(), DateFinished = new DateTime(2021, 11, 14, 12, 0, 0).ToUniversalTime() },
                 new TaskItem { TaskName = "Take out the rubbish", TaskDescription = "Take our the rubbish before collection happens next day", EstimatedTaskTime = 0.25, DateStarted = new DateTime(2018, 6, 1, 8, 0, 0).ToUniversalTime(), DateFinished = new DateTime(2021, 11, 2, 12, 0, 0).ToUniversalTime() } };

                _ctx.TaskItems.AddRange(_task);
                _ctx.SaveChanges();
            }
        }
    }
}
