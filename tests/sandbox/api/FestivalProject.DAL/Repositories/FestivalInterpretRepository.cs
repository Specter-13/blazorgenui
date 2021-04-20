using System;
using System.Linq;
using FestivalProject.DAL.Entities;

namespace FestivalProject.DAL.Repositories
{
    public class FestivalInterpretRepository 
    {
        private readonly FestivalDbContext _dbContext;

        public FestivalInterpretRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public FestivalInterpretEntity Create(FestivalInterpretEntity item)
        {
            _dbContext.FestivalInterprets.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public FestivalInterpretEntity Update(FestivalInterpretEntity item)
        {
            _dbContext.FestivalInterprets.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id1, Guid id2)
        {
            var entity = _dbContext.FestivalInterprets.First(t => t.FestivalId == id1 && t.InterpretId == id2);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
