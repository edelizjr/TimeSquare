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
    [Route("api/v1/[controller]")]
    public class TestsController : Controller
    {
        private readonly ITestCaseRepository _testRepository;

        public TestsController(ITestCaseRepository testRepository)
        {
            _testRepository = testRepository;
        }

        //[NoCache]
        //[HttpGet]
        //public async Task<IEnumerable<object>> Get()
        //{
        //    return await _testRepository.GetAllNotes();// GetAllNotes();
        //}

        //public async Task<IEnumerable<TestCase>> Get(string date)
        //{
        //    return await _testRepository.GetAllTestsByDate(date);// GetAllNotes();
        //}

       

        //public async Task<IEnumerable<TestCase>> GetResultsByDateRange(string startDate, string endDate)
        //{
        //    return await _testRepository.GetAllTestsByDate(startDate, endDate);// GetAllNotes();
        //}

        public async Task<IEnumerable<object>> GetResultsByDateRange(string date, string endDate, string sort, int limit)
        {
            return await _testRepository.GetAllTestsByDate(date, endDate, sort, limit);// GetAllNotes();
        }

        [HttpGet("counts")]
        public async Task<IEnumerable<object>> GetResultsByCount(string date, string endDate, string sort, int limit)
        {
            return await _testRepository.GetResultsCountByDate(date, endDate, sort, limit);// GetAllNotes();
        }




















        // GET api/notes/5
        //[HttpGet("{id}")]
        //public async Task<TestCase> Get(string id)
        //{
        //    return await _testRepository.GetNote(id) ?? new TestCase();
        //}











































        //// GET api/notes/text/date/size
        //// ex: http://localhost:53617/api/notes/Test/2018-01-01/10000
        //[NoCache]
        //[HttpGet(template: "{bodyText}/{updatedFrom}/{headerSizeLimit}")]
        //public async Task<IEnumerable<TestCase>> Get(string bodyText,
        //                                         DateTime updatedFrom,
        //                                         long headerSizeLimit)
        //{
        //    return await _testRepository.GetNote(bodyText, updatedFrom, headerSizeLimit)
        //                ?? new List<TestCase>();
        //}

        //// POST api/notes
        //[HttpPost]
        //public void Post([FromBody] TestCaseParam newNote)
        //{
        //    _testRepository.AddNote(new TestCase
        //    {
        //        Id = newNote.Id,
        //        Body = newNote.Body,
        //        UpdatedOn = DateTime.Now,
        //        Testcase = newNote.Testcase,
        //        UserId = newNote.UserId,
        //        ExecutionTime = newNote.ExecutionTime,
        //        MachineName = newNote.MachineName,
        //        OperatingSystem = newNote.OperatingSystem,
        //        AvgCpuUsage = newNote.AvgCpuUsage,
        //        DateOfExecution = newNote.DateOfExecution,
        //        AvgRamUsage = newNote.AvgRamUsage,
        //        Result = newNote.Result,
        //        AvgNetworkUsage = newNote.AvgNetworkUsage,
        //        Category = newNote.Category,
        //        Author = newNote.Author,
        //        Description = newNote.Description,
        //        Harness = newNote.Harness,
        //        Squad = newNote.Squad,
        //        Date = DateTime.Now.Date,
        //        Duration = newNote.Duration,
        //        Screenshot = newNote.Screenshot,
        //        Video = newNote.Video,
        //        ScreenshotAzure = newNote.ScreenshotAzure,
        //        VideoAzure = newNote.VideoAzure,
        //        LogFileLocation = newNote.LogFileLocation,
        //        LogFileLocationAzure = newNote.LogFileLocationAzure,
        //    });
        //}

        //// PUT api/notes/5
        //[HttpPut("{id}")]
        //public void Put(string id, [FromBody]string value)
        //{
        //    _testRepository.UpdateNoteDocument(id, value);
        //}

        //// DELETE api/notes/23243423
        //[HttpDelete("{id}")]
        //public void Delete(string id)
        //{
        //    _testRepository.RemoveNote(id);
        //}
    }
}
