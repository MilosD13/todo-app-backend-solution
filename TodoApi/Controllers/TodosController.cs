﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoLibrary.DataAccess;
using TodoLibrary.Models;

namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TodosController : ControllerBase
{
    private readonly ITodoData _data;
    private readonly ILogger<TodosController> _logger;
    public TodosController(ITodoData data, ILogger<TodosController> logger)
    {
        _data = data;
        _logger = logger;
    }

    private int GetUserId()
    {
        var userIdText = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userIdText);
    }

    // GET: api/Todos
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<List<TodoModel>>> Get()
    {
        _logger.LogInformation("GET: api/Todos");
        try
        {
            var output = await _data.GetAll(GetUserId());
            return Ok(output);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get call to api/Todos failed");
            return BadRequest();
        }
        
    }

    // GET api/Todos/5
    [HttpGet("{todoId}")]
    public async Task<ActionResult<List<TodoModel>>> Get(int todoId)
    {
        _logger.LogInformation("GET: api/Todos/id");
        try
        {
            var output = await _data.GetOne(GetUserId(), todoId);

            return Ok(output);
        }
        catch (Exception ex)
        {

            _logger.LogError(ex, "Get call to api/Todos/{todoId} failed", todoId);
            return BadRequest();
        }
    }

    // POST api/Todos
    [HttpPost]
    public async Task<ActionResult<TodoModel>> Post([FromBody] string task)
    {
        _logger.LogInformation("POST: api/Todos (Task: {Task})", task);

        try
        {
            var output = await _data.Create(GetUserId(), task);
            return Ok(output);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Post call to api/Todos failed. Task value was {Task}", task);
            return BadRequest();
        }
    }

    // PUT api/Todos/5
    [HttpPut("{todoId}")]
    public async Task<IActionResult> Put(int todoId, [FromBody] string task)
    {
        _logger.LogInformation("PUT: api/Todos/{TodoId} (Task: {Task})", todoId, task);
        try
        {
            await _data.UpdateTask(GetUserId(), todoId, task);

            return Ok();
        }
        catch (Exception ex)
        {

            _logger.LogError(ex, "Put call to api/Todos/{TodoId} failed. Task value was {Task}", todoId, task);
            return BadRequest();
        }
    }

    // PUT api/Todos/5/Complete
    [HttpPut("{todoId}/Complete")]
    public async Task<IActionResult> Complete(int todoId)
    {
        _logger.LogInformation("PUT: api/Todos/{TodoId}/Complete", todoId);
        try
        {
            await _data.CompleteTodo(GetUserId(), todoId);

            return Ok();
        }
        catch (Exception ex)
        {

            _logger.LogError(ex, "Put call to api/Todos/{TodoId}/Complete failed.", todoId);
            return BadRequest();
        }
    }

    // DELETE api/Todos/5
    [HttpDelete("{todoId}")]
    public async Task<IActionResult> Delete(int todoId)
    {
        _logger.LogInformation("Delete: api/Todos/{TodoId}", todoId);
        try
        {
            await _data.Delete(GetUserId(), todoId);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete call to api/Todos/{TodoId} failed.", todoId);
            return BadRequest();
        }
    }
}
