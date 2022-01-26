using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.ViewModels
{
    public class TaskItemViewModel
    {
        public int TaskID { get;  }
        [Required(ErrorMessage = "Task name is a required field")]
        [MinLength(3, ErrorMessage = "Task name must have at least 3 characters length")]
        [MaxLength(25, ErrorMessage = "Task name must have no more than 25 characters length")]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public double EstimatedTaskTime { get; set; }
        [Required(ErrorMessage = "Date started is a required field")]
        public DateTime DateStarted { get; set; }
        public DateTime DateFinished { get; set; }
        [MaxLength(200, ErrorMessage = "A comment must not have more than 200 characters")]
        public String Comment { get; set; }
    }
}
