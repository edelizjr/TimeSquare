using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSquare.Interfaces;
using TimeSquare.Model;

namespace TimeSquare.Controllers
{
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly INoteRepository _noteRepository;

        public SystemController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // Call an initialization - api/system/init
        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if (setting == "init")
            {
                _noteRepository.RemoveAllNotes();
                var name = _noteRepository.CreateIndex();

                _noteRepository.AddNote(new Note()
                {
                    Id = "1",
                    Body = "Test note 1",
                    UpdatedOn = DateTime.Now,
                    UserId = 1,
                    Testcase = "TestCase 1",
                    ExecutionTime = "ExecutionTime 1",
                    MachineName = "MachineName 1",
                    OperatingSystem = "OperatingSystem 1",
                    AvgCpuUsage = "AvgCpuUsage 1",
                    DateOfExecution = "DateOfExecution 1",
                    AvgRamUsage = "AvgRamUsage 1",
                    Result = "Result 1",
                    AvgNetworkUsage = "AvgNetworkUsage 1",
                    Category = "Category 1",
                    Author = "Author 1",
                    Description = "Description 1",
                    Harness = "Harness 1",
                    Squad = "Squad 1",
                    Date = "Date 1",
                    Duration = "Duration 1",
                    Screenshot = "Screenshot 1",
                    Video = "Video 1",
                    ScreenshotAzure = "ScreenshotAzure 1",
                    VideoAzure = "VideoAzure 1",
                    LogFileLocation = "LogFileLocation 1",
                    LogFileLocationAzure = "LogFileLocationAzure 1",
                    HeaderImage = new NoteImage
                    {
                        ImageSize = 10,
                        Url = "http://localhost/image1.png",
                        ThumbnailUrl = "http://localhost/image1_small.png"
                    }
                });

                _noteRepository.AddNote(new Note()
                {
                    Id = "2",
                    Body = "Test note 2",
                    UpdatedOn = DateTime.Now,
                    UserId = 1,
                    Testcase = "TestCase 2",
                    ExecutionTime = "ExecutionTime 2",
                    MachineName = "MachineName 2",
                    OperatingSystem = "OperatingSystem 2",
                    AvgCpuUsage = "AvgCpuUsage 2",
                    DateOfExecution = "DateOfExecution 2",
                    AvgRamUsage = "AvgRamUsage 2",
                    Result = "Result 2",
                    AvgNetworkUsage = "AvgNetworkUsage 2",
                    Category = "Category 2",
                    Author = "Author 2",
                    Description = "Description 2",
                    Harness = "Harness 2",
                    Squad = "Squad 2",
                    Date = "Date 2",
                    Duration = "Duration 2",
                    Screenshot = "Screenshot 2",
                    Video = "Video 2",
                    ScreenshotAzure = "ScreenshotAzure 2",
                    VideoAzure = "VideoAzure 2",
                    LogFileLocation = "LogFileLocation 2",
                    LogFileLocationAzure = "LogFileLocationAzure 2",
                    HeaderImage = new NoteImage
                    {
                        ImageSize = 13,
                        Url = "http://localhost/image2.png",
                        ThumbnailUrl = "http://localhost/image2_small.png"
                    }
                });

                _noteRepository.AddNote(new Note()
                {
                    Id = "3",
                    Body = "Test note 3",
                    UpdatedOn = DateTime.Now,
                    UserId = 1,
                    Testcase = "TestCase 3",
                    ExecutionTime = "ExecutionTime 3",
                    MachineName = "MachineName 3",
                    OperatingSystem = "OperatingSystem 3",
                    AvgCpuUsage = "AvgCpuUsage 3",
                    DateOfExecution = "DateOfExecution 3",
                    AvgRamUsage = "AvgRamUsage 3",
                    Result = "Result 3",
                    AvgNetworkUsage = "AvgNetworkUsage 3",
                    Category = "Category 3",
                    Author = "Author 3",
                    Description = "Description 3",
                    Harness = "Harness 3",
                    Squad = "Squad 3",
                    Date = "Date 3",
                    Duration = "Duration 3",
                    Screenshot = "Screenshot 3",
                    Video = "Video 3",
                    ScreenshotAzure = "ScreenshotAzure 3",
                    VideoAzure = "VideoAzure 3",
                    LogFileLocation = "LogFileLocation 3",
                    LogFileLocationAzure = "LogFileLocationAzure 3",
                    HeaderImage = new NoteImage
                    {
                        ImageSize = 14,
                        Url = "http://localhost/image3.png",
                        ThumbnailUrl = "http://localhost/image3_small.png"
                    }
                });

                _noteRepository.AddNote(new Note()
                {
                    Id = "4",
                    Body = "Test note 4",
                    UpdatedOn = DateTime.Now,
                    UserId = 1,
                    Testcase = "TestCase 4",
                    ExecutionTime = "ExecutionTime 4",
                    MachineName = "MachineName 4",
                    OperatingSystem = "OperatingSystem 4",
                    AvgCpuUsage = "AvgCpuUsage 4",
                    DateOfExecution = "DateOfExecution 4",
                    AvgRamUsage = "AvgRamUsage 4",
                    Result = "Result 4",
                    AvgNetworkUsage = "AvgNetworkUsage 4",
                    Category = "Category 4",
                    Author = "Author 4",
                    Description = "Description 4",
                    Harness = "Harness 4",
                    Squad = "Squad 4",
                    Date = "Date 4",
                    Duration = "Duration 4",
                    Screenshot = "Screenshot 4",
                    Video = "Video 4",
                    ScreenshotAzure = "ScreenshotAzure 4",
                    VideoAzure = "VideoAzure 4",
                    LogFileLocation = "LogFileLocation 4",
                    LogFileLocationAzure = "LogFileLocationAzure 4",
                    HeaderImage = new NoteImage
                    {
                        ImageSize = 15,
                        Url = "http://localhost/image4.png",
                        ThumbnailUrl = "http://localhost/image4_small.png"
                    }
                });

                return "Database NotesDb was created, and collection 'Notes' was filled with 4 sample items";
            }

            return "Unknown";
        }
    }
}
