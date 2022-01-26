using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Data.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskID { get; set; }
      //  [Required]
      //  [MinLength(1)]
     //   [MaxLength(25)]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public double EstimatedTaskTime { get; set; }
     //   [Required]
        public DateTime DateStarted { get; set; }
        public DateTime DateFinished { get; set; }
     //   [MaxLength(200)]
        public String Comment { get; set; }

    }
}
