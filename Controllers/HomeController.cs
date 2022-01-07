using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    public class HomeController: ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get( [FromServices] AppDbContext context )
        => Ok(context.Todos.ToList());
        

        [HttpGet("/{id:int}")]
        public IActionResult GetById( [FromServices] AppDbContext context, [FromRoute] int id)
        {
            var todos = context.Todos.FirstOrDefault(x => x.Id == id);

            if(todos == null)
                return NotFound();

            
            return Ok(todos);
        }

        [HttpPost("/")]
        public IActionResult Post([FromServices] AppDbContext context, [FromBody] TodoModel model){

            model.CreatedAt = DateTime.Now;
            context.Todos.Add(model);
            context.SaveChanges();

            return Created($"{model.Id}", model);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromServices] AppDbContext context, 
            [FromBody] TodoModel todo)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);

            if(model == null) return NotFound();

            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();

            return Ok(model);

        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context
            )
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);

            if(model == null)
                return NotFound();

            context.Todos.Remove(model);
            context.SaveChanges();

            return Ok(model);
        }

    }
}