using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Data.Models;
using TaskTracker.ViewModels;

namespace TaskTracker.Data
{
    public class TaskTrackerMappingProfile : Profile
    {
        public TaskTrackerMappingProfile()
        {
            InitMapping();
        }

        public void InitMapping()
        {
            CreateMap<TaskItem, TaskItemViewModel>();
        }
    }
}
