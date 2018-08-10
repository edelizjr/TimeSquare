using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSquare.Model
{
    public class NoteParam
    {
        public string Id { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Testcase { get; set; } = string.Empty;
        public int UserId { get; set; } = 0;

        public string ExecutionTime { get; set; } = string.Empty;
        public string MachineName { get; set; } = string.Empty;
        public string OperatingSystem { get; set; } = string.Empty;
        public string AvgCpuUsage { get; set; } = string.Empty;
        public string DateOfExecution { get; set; } = string.Empty;
        public string AvgRamUsage { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string AvgNetworkUsage { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Harness { get; set; } = string.Empty;
        public string Squad { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Screenshot { get; set; } = string.Empty;
        public string Video { get; set; } = string.Empty;
        public string ScreenshotAzure { get; set; } = string.Empty;
        public string VideoAzure { get; set; } = string.Empty;
        public string LogFileLocation { get; set; } = string.Empty;
        public string LogFileLocationAzure { get; set; } = string.Empty;
    }
}
