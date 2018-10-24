using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSquare.Model;

namespace TimeSquare.Interfaces
{
    public interface ITestCaseRepository
    {
        Task<IEnumerable<TestCase>> GetAllNotes();

        //Task<IEnumerable<object>> GetResultsCount();

        // Task<IEnumerable<TestCase>> GetAllTestsByDate(string date);

        Task<IEnumerable<object>> GetResultsCountByDate(string startDate, string endDatestring, string sort, int limit);

        //Task<IEnumerable<TestCase>> GetAllTestsByDate(string startDate, string endDate);

        Task<IEnumerable<object>> GetAllTestsByDate(string date, string endDate, string sort, int limit);







        Task<TestCase> GetNote(string id);


        // query after multiple parameters
        Task<IEnumerable<TestCase>> GetNote(string bodyText, DateTime updatedFrom, long headerSizeLimit);

        // add new note document
        Task AddNote(TestCase item);

        // remove a single document / note
        Task<bool> RemoveNote(string id);

        // update just a single document / note
        Task<bool> UpdateNote(string id, string body);

        // demo interface - full document update
        Task<bool> UpdateNoteDocument(string id, string body);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAllNotes();

        // creates a sample index
        Task<string> CreateIndex();
    }
}
