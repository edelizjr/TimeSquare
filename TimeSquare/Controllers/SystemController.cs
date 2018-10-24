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
        private readonly ITestCaseRepository _noteRepository;

        public SystemController(ITestCaseRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // Call an initialization - api/system/init
        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if (setting == "init")
            {
                //_noteRepository.RemoveAllNotes();
                var name = _noteRepository.CreateIndex();

                for (var r = 0; r < 150; r++)
                {
                    _noteRepository.AddNote(new TestCase()
                    {
                        Id = "1",
                        Body = "Test note " + r,
                        UpdatedOn = DateTime.Now,
                        UserId = 1,
                        Testcase = "TestCase " + r,
                        ExecutionTime = "ExecutionTime " + r,
                        MachineName = "MachineName " + r,
                        OperatingSystem = "OperatingSystem " + r,
                        AvgCpuUsage = "AvgCpuUsage " + r,
                        DateOfExecution = "DateOfExecution " + r,
                        AvgRamUsage = "AvgRamUsage " + r,
                        Result = r% 2 == 0 ? "Passed" : "Failed",
                        AvgNetworkUsage = "AvgNetworkUsage " + r,
                        Category = "Category " + r,
                        Author = "Author " + r,
                        Description = "Description " + r,
                        Harness = "Harness " + r,
                        Squad = "Squad " + r + r,
                        Date = DateTime.Now.Date.AddDays(-1),
                        Duration = "Duration ",
                        Screenshot = "Screenshot " + r,
                        Video = "Video " + r,
                        ScreenshotAzure = "ScreenshotAzure " + r,
                        VideoAzure = "VideoAzure " + r,
                        LogFileLocation = "LogFileLocation " + r,
                        LogFileLocationAzure = "LogFileLocationAzure " + r,
                        HeaderImage = new TestCaseImage
                        {
                            ImageSize = 10,
                            Url = "http://localhost/image1.png",
                            ThumbnailUrl = "http://localhost/image1_small.png"
                        }
                    });
                }

                //_noteRepository.AddNote(new TestCase()
                //{
                //    Id = "2",
                //    Body = "Test note 2",
                //    UpdatedOn = DateTime.Now,
                //    UserId = 1,
                //    Testcase = "TestCase 2",
                //    ExecutionTime = "ExecutionTime 2",
                //    MachineName = "MachineName 2",
                //    OperatingSystem = "OperatingSystem 2",
                //    AvgCpuUsage = "AvgCpuUsage 2",
                //    DateOfExecution = "DateOfExecution 2",
                //    AvgRamUsage = "AvgRamUsage 2",
                //    Result = "Result 2",
                //    AvgNetworkUsage = "AvgNetworkUsage 2",
                //    Category = "Category 2",
                //    Author = "Author 2",
                //    Description = "Description 2",
                //    Harness = "Harness 2",
                //    Squad = "Squad 2",
                //    Date = DateTime.Now.Date,
                //    Duration = "Duration 2",
                //    Screenshot = "Screenshot 2",
                //    Video = "Video 2",
                //    ScreenshotAzure = "ScreenshotAzure 2",
                //    VideoAzure = "VideoAzure 2",
                //    LogFileLocation = "LogFileLocation 2",
                //    LogFileLocationAzure = "LogFileLocationAzure 2",
                //    HeaderImage = new TestCaseImage
                //    {
                //        ImageSize = 13,
                //        Url = "http://localhost/image2.png",
                //        ThumbnailUrl = "http://localhost/image2_small.png"
                //    }
                //});

                //_noteRepository.AddNote(new TestCase()
                //{
                //    Id = "3",
                //    Body = "Test note 3",
                //    UpdatedOn = DateTime.Now,
                //    UserId = 1,
                //    Testcase = "TestCase 3",
                //    ExecutionTime = "ExecutionTime 3",
                //    MachineName = "MachineName 3",
                //    OperatingSystem = "OperatingSystem 3",
                //    AvgCpuUsage = "AvgCpuUsage 3",
                //    DateOfExecution = "DateOfExecution 3",
                //    AvgRamUsage = "AvgRamUsage 3",
                //    Result = "Result 3",
                //    AvgNetworkUsage = "AvgNetworkUsage 3",
                //    Category = "Category 3",
                //    Author = "Author 3",
                //    Description = "Description 3",
                //    Harness = "Harness 3",
                //    Squad = "Squad 3",
                //    Date = DateTime.Now.Date,
                //    Duration = "Duration 3",
                //    Screenshot = "Screenshot 3",
                //    Video = "Video 3",
                //    ScreenshotAzure = "ScreenshotAzure 3",
                //    VideoAzure = "VideoAzure 3",
                //    LogFileLocation = "LogFileLocation 3",
                //    LogFileLocationAzure = "LogFileLocationAzure 3",
                //    HeaderImage = new TestCaseImage
                //    {
                //        ImageSize = 14,
                //        Url = "http://localhost/image3.png",
                //        ThumbnailUrl = "http://localhost/image3_small.png"
                //    }
                //});

                //_noteRepository.AddNote(new TestCase()
                //{
                //    Id = "4",
                //    Body = "Test note 4",
                //    UpdatedOn = DateTime.Now,
                //    UserId = 1,
                //    Testcase = "TestCase 4",
                //    ExecutionTime = "ExecutionTime 4",
                //    MachineName = "MachineName 4",
                //    OperatingSystem = "OperatingSystem 4",
                //    AvgCpuUsage = "AvgCpuUsage 4",
                //    DateOfExecution = "DateOfExecution 4",
                //    AvgRamUsage = "AvgRamUsage 4",
                //    Result = "Result 4",
                //    AvgNetworkUsage = "AvgNetworkUsage 4",
                //    Category = "Category 4",
                //    Author = "Author 4",
                //    Description = "Description 4",
                //    Harness = "Harness 4",
                //    Squad = "Squad 4",
                //    Date = DateTime.Now.Date,
                //    Duration = "Duration 4",
                //    Screenshot = "Screenshot 4",
                //    Video = "Video 4",
                //    ScreenshotAzure = "ScreenshotAzure 4",
                //    VideoAzure = "VideoAzure 4",
                //    LogFileLocation = "LogFileLocation 4",
                //    LogFileLocationAzure = "LogFileLocationAzure 4",
                //    HeaderImage = new TestCaseImage
                //    {
                //        ImageSize = 15,
                //        Url = "http://localhost/image4.png",
                //        ThumbnailUrl = "http://localhost/image4_small.png"
                //    }
                //});

                return "Database NotesDb was created, and collection 'Notes' was filled with 4 sample items";
            }

            return "Unknown";
        }
    }
}
