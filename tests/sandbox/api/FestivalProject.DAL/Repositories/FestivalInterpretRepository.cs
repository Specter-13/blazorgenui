using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;

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
