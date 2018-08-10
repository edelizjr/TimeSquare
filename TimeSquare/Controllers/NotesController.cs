using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSquare.Infrastructure;
using TimeSquare.Interfaces;
using TimeSquare.Model;

namespace TimeSquare.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<Note>> Get()
        {
            return await _noteRepository.GetAllNotes();
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public async Task<Note> Get(string id)
        {
            return await _noteRepository.GetNote(id) ?? new Note();
        }

        // GET api/notes/text/date/size
        // ex: http://localhost:53617/api/notes/Test/2018-01-01/10000
        [NoCache]
        [HttpGet(template: "{bodyText}/{updatedFrom}/{headerSizeLimit}")]
        public async Task<IEnumerable<Note>> Get(string bodyText,
                                                 DateTime updatedFrom,
                                                 long headerSizeLimit)
        {
            return await _noteRepository.GetNote(bodyText, updatedFrom, headerSizeLimit)
                        ?? new List<Note>();
        }

        // POST api/notes
        [HttpPost]
        public void Post([FromBody] NoteParam newNote)
        {
            _noteRepository.AddNote(new Note
            {
                Id = newNote.Id,
                Body = newNote.Body,
                UpdatedOn = DateTime.Now,
                Testcase = newNote.Testcase,
                UserId = newNote.UserId,
                ExecutionTime = newNote.ExecutionTime,
                MachineName = newNote.MachineName,
                OperatingSystem = newNote.OperatingSystem,
                AvgCpuUsage = newNote.AvgCpuUsage,
                DateOfExecution = newNote.DateOfExecution,
                AvgRamUsage = newNote.AvgRamUsage,
                Result = newNote.Result,
                AvgNetworkUsage = newNote.AvgNetworkUsage,
                Category = newNote.Category,
                Author = newNote.Author,
                Description = newNote.Description,
                Harness = newNote.Harness,
                Squad = newNote.Squad,
                Date = newNote.Date,
                Duration = newNote.Duration,
                Screenshot = newNote.Screenshot,
                Video = newNote.Video,
                ScreenshotAzure = newNote.ScreenshotAzure,
                VideoAzure = newNote.VideoAzure,
                LogFileLocation = newNote.LogFileLocation,
                LogFileLocationAzure = newNote.LogFileLocationAzure,
            });
        }

        // PUT api/notes/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value)
        {
            _noteRepository.UpdateNoteDocument(id, value);
        }

        // DELETE api/notes/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _noteRepository.RemoveNote(id);
        }
    }
}
