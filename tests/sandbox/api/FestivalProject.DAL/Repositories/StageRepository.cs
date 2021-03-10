using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FestivalProject.DAL.Repositories
{
    public class StageRepository : IGenericCrudOperations<StageEntity>
    {
        private readonly FestivalDbContext _dbContext;

        public StageRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<StageEntity> GetAll()
        {
            return _dbContext.Stages.ToList();
        }

        public StageEntity GetById(Guid id)
        {
            return _dbContext.Stages.Include(x => x.StageInterpret)
                    .ThenInclude(x => x.Interpret)
                .Include(x => x.Festival)
                .First(x => x.Id == id);
        }

        public StageEntity Create(StageEntity item)
        {
            _dbContext.Stages.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public StageEntity Update(StageEntity item)
        {
            _dbContext.Stages.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {
            //remove stageInterpret
            _dbContext.StageInterprets
                .RemoveRange(_dbContext.StageInterprets.Where((x => x.StageId == id)));
            //remove stage
            var entity = _dbContext.Stages.First(t => t.Id == id);
            _dbContext.Remove(entity);

            _dbContext.SaveChanges();
           
        }
    }
}
