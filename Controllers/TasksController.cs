using Microsoft.AspNetCore.Mvc;
using ToDoTask.DTOs;
using ToDoTask.Interfaces;

namespace ToDoTask.Controllers;


[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITasksService _taskService;
    public TasksController(ITasksService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetTaskList()
    {
        try
        {
            return Ok(await _taskService.GetTaskList());
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{idTask}")]
    public async Task<IActionResult> GetTask(int idTask)
    {
        try
        {
            return Ok(await _taskService.GetTaskById(idTask));
        }
        catch (Exception e)
        {
            if( e.Message == "Id task does not exist!")
                 return StatusCode(404, e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost()]
    public async Task<IActionResult> CreateTask(TasksDTO task)
    {
        try
        {
            return Ok(await _taskService.CreateTask(task));
        }
        catch (Exception e)
        {
            if( e.Message == "Task's title can't be null or empty")
                 return StatusCode(404, e.Message);
            return StatusCode(500, e.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTask(TasksDTO task)
    {
        try
        {
            return Ok(await _taskService.UpdateTask(task));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{idTask}")]
    public async Task<IActionResult> DeleteTask(int idTask)
    {
        try
        {
            return Ok(await _taskService.DeleteTask(idTask));
        }
        catch (Exception e)
        {
            if( e.Message == "Id task does not exist!")
                 return StatusCode(404, e.Message);
            return StatusCode(500, e.Message);
        }
    }
}