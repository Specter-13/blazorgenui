using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FestivalProject.DAL
{
    public class InMemoryDbContextFactory 
    {
        private readonly string _testDbName;
        public InMemoryDbContextFactory(string testDbName) => _testDbName = testDbName;

        public FestivalDbContext CreateDbContext()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<FestivalDbContext>();
            dbContextOptionsBuilder.UseInMemoryDatabase(_testDbName);
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
            return new FestivalDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
