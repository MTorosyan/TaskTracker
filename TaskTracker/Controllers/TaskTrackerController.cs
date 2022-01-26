using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Data;
using TaskTracker.Data.Models;
using TaskTracker.Services;
using TaskTracker.ViewModels;

namespace TaskTracker.Controllers
{
    public class TaskTrackerController : Controller
    {
        private readonly ITaskTracker _taskTracker;
        private readonly TaskTrackerContext _context;

        public TaskTrackerController(ITaskTracker taskTracker, TaskTrackerContext context)
        {
            _taskTracker = taskTracker;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_taskTracker.GetAllTaskItems());
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int id)
        {
            var currentTask = _taskTracker.GetTaskItem(id);
            var displayViewModelData = new TaskItemViewModel() {TaskName = currentTask.TaskName, TaskDescription = currentTask.TaskDescription, EstimatedTaskTime = currentTask.EstimatedTaskTime, DateStarted = currentTask.DateStarted, DateFinished = currentTask.DateFinished, Comment = currentTask.Comment};
            return View(displayViewModelData);
        }

        [HttpPost("Edit")]
        public IActionResult Edit(int id, TaskItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var taskTracker = new TaskItem() {TaskID = id, TaskName = model.TaskName, TaskDescription = model.TaskDescription, EstimatedTaskTime = model.EstimatedTaskTime, DateStarted = model.DateStarted, DateFinished = model.DateFinished, Comment = model.Comment};
                _taskTracker.UpdateTaskItem(taskTracker);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet("Delete")] //change this to be a delete HTTP call
        public IActionResult Delete(int id)
        {
            var currentTask = _taskTracker.GetTaskItem(id);
            var displayViewModelData = new TaskItemViewModel() {TaskName = currentTask.TaskName, TaskDescription = currentTask.TaskDescription, EstimatedTaskTime = currentTask.EstimatedTaskTime, DateStarted = currentTask.DateStarted, DateFinished = currentTask.DateFinished, Comment = currentTask.Comment };
            return View(displayViewModelData);
        }

        [HttpPost("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _taskTracker.DeleteTaskItem(id);
            return RedirectToAction("Index");
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(TaskItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var createANewItem = new TaskItem() { TaskName = model.TaskName, TaskDescription = model.TaskDescription, EstimatedTaskTime = model.EstimatedTaskTime, DateStarted = model.DateStarted, DateFinished = model.DateFinished, Comment = model.Comment };
                _taskTracker.CreateTaskItem(createANewItem);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var currentItem = _taskTracker.GetTaskItem(id);

            return View(currentItem);
        }


    }
}