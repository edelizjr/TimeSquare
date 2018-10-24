using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSquare.Interfaces;
using TimeSquare.Model;

namespace TimeSquare.Data
{
    public class TestCaseRepository : ITestCaseRepository
    {
        private readonly TestCaseContext _context = null;

        public TestCaseRepository(IOptions<Settings> settings)
        {
            _context = new TestCaseContext(settings);
        }

        public async Task<IEnumerable<TestCase>> GetAllNotes()
        {
            try
            {
                return await _context.Notes.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


        public async Task<IEnumerable<TestCase>> GetAllTestsByDate(string date)
        {
            try
            {
                return await _context.Notes.Aggregate()
                    .Match(r => r.Date == DateTime.Parse(date))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        //public async Task<IEnumerable<TestCase>> AllTestsByDate(string date, string endDate, string sort, int? limit)
        //{
        //    try
        //    {
        //        var aggregate = _context.Notes.Aggregate()
        //            .Match(r => r.Date >= DateTime.Parse(date) && r.Date <= DateTime.Parse(endDate));
        //        var results = await aggregate.ToListAsync();
        //        var sorting = await aggregate.Sort(sort).ToListAsync();
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        // log or manage the exception
        //        throw ex;
        //    }
        //}

        public async Task<IEnumerable<object>> GetAllTestsByDate(string date, string endDate, string sort, int limit)
        {
            IAggregateFluent<TestCase> aggregate = null;
            try
            {
                if (string.IsNullOrEmpty(date) && string.IsNullOrEmpty(endDate))
                {
                    aggregate = _context.Notes.Aggregate()
                   .Match(r => r.Date == DateTime.Now.Date);


                }
                if (!string.IsNullOrEmpty(date) && string.IsNullOrEmpty(endDate))
                {
                    aggregate = _context.Notes.Aggregate()
                  .Match(r => r.Date == DateTime.Parse(date));
                }
                if (!string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(endDate))
                {
                    aggregate = _context.Notes.Aggregate()
                   .Match(r => r.Date >= DateTime.Parse(date).Date && r.Date <= DateTime.Parse(endDate).Date);
                }
                if ((limit != 0))
                {
                    aggregate = aggregate.Limit(Convert.ToInt32(limit));
                }

                if (!string.IsNullOrEmpty(sort))
                {
                    aggregate = aggregate.Sort(Builders<TestCase>.Sort.Descending(x => x.Result));
                    // aggregate = aggregate.Sort(Builders<TestCase>.Sort.Descending(sort));
                    // aggregate = aggregate.Sort(Builders<TestCase>.Sort.Ascending(sort));
                }


                var results = await aggregate.ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<IEnumerable<object>> GetResultsCountByDate(string date, string endDate, string sort, int limit)
        {
            var aggregate = _context.Notes.Aggregate()
                .Project(x => new { x.Date, x.Result })
                .Match(r => r.Date >= DateTime.Parse(date).Date && r.Date <= DateTime.Parse(endDate).Date)
                .Group(k => new
                {
                   date = k.Date,
                   failed = k.Result == "Failed",
                   passed = k.Result == "Passed"
        },
                g => new { _id = g.Key, count = g.Count() }
              );

            //.Group(v => v.Result , g => new { g.Key, Count = g.Count() });
            var results = await aggregate.ToListAsync();
            return results;
            //try
            //{
            //    return await _context.Notes.Aggregate()
            //        .Match(r => r.Date == DateTime.Parse(date).Date)
            //        .Project(r => new { r.Result })
            //        .Group(v => v.Result, g => new { g.Key, Count = g.Count() })
            //        .ToListAsync();
            //}
            //catch (Exception ex)
            //{
            //    // log or manage the exception
            //    throw ex;
            //}



            //IAggregateFluent<TestCase> aggregate = null;
            //try
            //{
            //    if (string.IsNullOrEmpty(date) && string.IsNullOrEmpty(endDate))
            //    {
            //        aggregate = _context.Notes.Aggregate()
            //       .Match(r => r.Date == DateTime.Now.Date);


            //    }
            //    if (!string.IsNullOrEmpty(date) && string.IsNullOrEmpty(endDate))
            //    {
            //        aggregate = _context.Notes.Aggregate()
            //      .Match(r => r.Date == DateTime.Parse(date));
            //    }
            //    if (!string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(endDate))
            //    {
            //        aggregate = _context.Notes.Aggregate()
            //       .Match(r => r.Date >= DateTime.Parse(date).Date && r.Date <= DateTime.Parse(endDate).Date);
            //    }
            //    if ((limit != 0))
            //    {
            //        aggregate = aggregate.Limit(Convert.ToInt32(limit));
            //    }

            //    if (!string.IsNullOrEmpty(sort))
            //    {
            //        aggregate = aggregate.Sort(Builders<TestCase>.Sort.Descending(x => x.Result));
            //        // aggregate = aggregate.Sort(Builders<TestCase>.Sort.Descending(sort));
            //        // aggregate = aggregate.Sort(Builders<TestCase>.Sort.Ascending(sort));
            //    }

            //    var totalCount = await aggregate.Group(v => v.Result, g => new { g.Key, Count = g.Count() }).ToListAsync();

            //    var results = await aggregate.ToListAsync();
            //    return totalCount;
            //}
            //catch (Exception ex)
            //{
            //    // log or manage the exception
            //    throw ex;
            //}


        }























        public int GetAllTests()
        {
            try
            {

                return _context.Notes.AsQueryable().Count(p => p.Result == "Passed");

            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }










        // query after Id or InternalId (BSonId value)
        //
        public async Task<TestCase> GetNote(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.Notes
                                .Find(note => note.Id == id || note.InternalId == internalId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // query after body text, updated time, and header image size
        //
        public async Task<IEnumerable<TestCase>> GetNote(string bodyText, DateTime updatedFrom, long headerSizeLimit)
        {
            try
            {
                var query = _context.Notes.Find(note => note.Body.Contains(bodyText) &&
                                       note.UpdatedOn >= updatedFrom &&
                                       note.HeaderImage.ImageSize <= headerSizeLimit);

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Try to convert the Id to a BSonId value
        private ObjectId GetInternalId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task AddNote(TestCase item)
        {
            try
            {
                await _context.Notes.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveNote(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Notes.DeleteOneAsync(
                     Builders<TestCase>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateNote(string id, string body)
        {
            var filter = Builders<TestCase>.Filter.Eq(s => s.Id, id);
            var update = Builders<TestCase>.Update
                            .Set(s => s.Body, body)
                            .CurrentDate(s => s.UpdatedOn);

            try
            {
                UpdateResult actionResult = await _context.Notes.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateNote(string id, TestCase item)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Notes
                                                .ReplaceOneAsync(n => n.Id.Equals(id)
                                                                , item
                                                                , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Demo function - full document update
        public async Task<bool> UpdateNoteDocument(string id, string body)
        {
            var item = await GetNote(id) ?? new TestCase();
            item.Body = body;
            item.UpdatedOn = DateTime.Now;

            return await UpdateNote(id, item);
        }

        public async Task<bool> RemoveAllNotes()
        {
            try
            {
                DeleteResult actionResult = await _context.Notes.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // it creates a sample compound index (first using UserId, and then Body)
        // 
        // MongoDb automatically detects if the index already exists - in this case it just returns the index details
        public async Task<string> CreateIndex()
        {
            try
            {
                IndexKeysDefinition<TestCase> keys = Builders<TestCase>
                                                    .IndexKeys
                                                    .Ascending(item => item.UserId)
                                                    .Ascending(item => item.Body);

                return await _context.Notes
                                .Indexes.CreateOneAsync(new CreateIndexModel<TestCase>(keys));
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }



        public Task<IEnumerable<TestCase>> GetAllTestsByDate(string startDate, string endDate)
        {
            throw new NotImplementedException();
        }
    }
}
