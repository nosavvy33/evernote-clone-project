using Evernote.Application.Validations;
using Evernote.Domain.IServices;
using Evernote.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Evernote.APIClone.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NotesController : Controller
    {

        private readonly INotesService NoteService;
        private readonly ILogger<NotesController> Logger;


        public NotesController(INotesService noteService, ILogger<NotesController> logger)
        {
            this.NoteService = noteService;
            this.Logger = logger;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await this.NoteService.ListAll());
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Method: " + HttpContext.Request.Method.ToString() + "\nPath: " + HttpContext.Request.Path.ToString());
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] NoteDTO note)
        {
            try
            {
                var x = await this.NoteService.Create(note);
                return Ok(x);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Method: " + HttpContext.Request.Method.ToString() + "\nPath: " + HttpContext.Request.Path.ToString());
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("whatever")]
        public async Task<IActionResult> Whatever([FromBody] Whatever note)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok();

                }
                else 
                {
                    return BadRequest();
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Method: " + HttpContext.Request.Method.ToString() + "\nPath: " + HttpContext.Request.Path.ToString());
                return BadRequest(exception.Message);
            }
        }
    }
}
