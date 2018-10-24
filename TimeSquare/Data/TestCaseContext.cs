using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSquare.Model;

namespace TimeSquare.Data
{
    public class TestCaseContext
    {
        private readonly IMongoDatabase _database = null;

        public TestCaseContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<TestCase> Notes
        {
            get
            {
                return _database.GetCollection<TestCase>("Tests");
            }
        }
    }
}
