namespace EasyTracker;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   


public class TaskContrller : ControllerBase
{
    private readonly ITaskManager _taskManager;

    public TaskContrller(ITaskManager taskManager)
    {
        _taskManager = taskManager;
    }   

    [HttpGet("/api/tasks/getall")]
    public IEnumerable<TrackerTask> GetAll()
    {
        return _taskManager.GetAllTasks();
    }

    [HttpGet("/api/tasks/get/{id}")]
    public TrackerTask Get(int id)
    {
        return _taskManager.GetTaskById(id);
    }


    [HttpPost("/api/tasks/add")]
    public void Create([FromBody] TrackerTask task)
    {
        _taskManager.AddTask(task);
    }

    [HttpGet("/api/tasks/delete/{id}")]
    public void Delete(int id)
    {
        var tasks = _taskManager.GetAllTasks();

        if(tasks.Count < 1)
            throw new Exception("No tasks found");

        TrackerTask targetTask = tasks.FirstOrDefault(t => t.ID == id);
        _taskManager.DeleteTask(targetTask);
    }


    [HttpGet("/api/tasks/addrandom/{id}")]
    public void AddRandom(int id)
    {
         for(int x = 0 ; x < id;x++ )
         {
            int lastTaskID = 0 ;
            try
            {
                var tasks = _taskManager.GetAllTasks(); 
                lastTaskID = tasks.Max(t => t.ID);   
            } 
            catch
            {
                lastTaskID = 0; 
            }
            
            var newTask = new TrackerTask();
            var randomName = "Task #" + (lastTaskID + x).ToString();
            newTask.ID = lastTaskID + x;       
            newTask.Name = randomName;  
            newTask.Description = "This is a random task";   
            _taskManager.AddTask(newTask); 
         }
    }
    
    [HttpPut("api/tasks/completed/{id}")]
    public void Completed(int id)
    {
        _taskManager.FinishTask(id);
    }
}