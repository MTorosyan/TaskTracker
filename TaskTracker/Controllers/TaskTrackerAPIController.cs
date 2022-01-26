using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Data;
using TaskTracker.Data.Models;
using TaskTracker.Services;
using TaskTracker.ViewModels;

namespace TaskTracker.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [EnableCors("ShedDevPolicy")]
    [Produces("application/json")]

    public class TaskTrackerAPIController : ControllerBase
    {
        private readonly ITaskTracker _taskTracker;
        private readonly IMapper _mapper;

        public TaskTrackerAPIController(ITaskTracker taskTracker, IMapper mapper)
        {
            _taskTracker = taskTracker;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        //Get All task Items
        public ActionResult<IEnumerable<TaskItem>> GetAll()
        {
            try
            {
                return Ok(_taskTracker.GetAllTaskItems());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        //specific read
        [HttpGet("{id:int}")]
        public ActionResult GetTaskItem(int id)
        {
            try
            {
                var singleTaskItem = _taskTracker.GetTaskItem(id);
                if (singleTaskItem != null)
                {
                    return Ok(_mapper.Map<TaskItem, TaskItemViewModel>(singleTaskItem));
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //create
        [Route("createnewtask")]
        [HttpPost]
        public IActionResult CreateTask([FromBody]TaskItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newTask = _mapper.Map<TaskItemViewModel, TaskItem>(model);
                    _taskTracker.CreateTaskItem(newTask);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //edit
        [Route("EditTask/{id:int}")]
        [HttpPut]
        public IActionResult EditTask(int id, [FromBody]TaskItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var singleTaskItem = _taskTracker.GetTaskItem(id);
                        if (singleTaskItem != null)
                        {
                            var editTask = _mapper.Map<TaskItemViewModel, TaskItem>(model);
                            editTask.TaskID = id;
                            _taskTracker.UpdateTaskItem(editTask);
                            return Ok();
                        }
                        else
                        {
                            return NotFound();
                        }
                }

                else
                {
                    return BadRequest(ModelState);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }

        //delete
        [Route("DeleteTask/{id:int}")]
        [HttpDelete]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                var singleTaskItem = _taskTracker.GetTaskItem(id);
                if (singleTaskItem != null)
                {
                    _taskTracker.DeleteTaskItem(id);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
