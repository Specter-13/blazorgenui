using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FestivalProject.DAL.Repositories
{
    public class FestivalRepository : IGenericCrudOperations<FestivalEntity>
    {
        private readonly FestivalDbContext _dbContext;
        public FestivalRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<FestivalEntity> GetAll()
        {
            return _dbContext.Festivals
                .Include(entity => entity.FestivalInterpret)
                .Include(entity => entity.StageList)
                .ToList();
        }

        public FestivalEntity GetById(Guid id)
        {
            return _dbContext.Festivals.Include(x => x.StageList)
                .ThenInclude(x => x.StageInterpret)
                .Include(x => x.FestivalInterpret)
                .ThenInclude(x => x.Interpret)
                .FirstOrDefault(x => x.Id == id);
        }

        public FestivalEntity Create(FestivalEntity item)
        {
            _dbContext.Festivals.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public FestivalEntity Update(FestivalEntity item)
        {
            _dbContext.Festivals.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {

            //remove FestivalInterprets, where FestivalId == id
            _dbContext.FestivalInterprets
                .RemoveRange(_dbContext.FestivalInterprets.Where((x => x.FestivalId == id)));

            //get all depended stages
            var stages = _dbContext.Stages.Where(x => x.FestivalId == id);

            //remove stageInterpret
            foreach (var stage in stages)
            {
                _dbContext.StageInterprets
                    .RemoveRange(_dbContext.StageInterprets.Where(x => x.StageId == stage.Id));
            }

            //remove stages
            _dbContext.Stages.RemoveRange(stages);

            //remove festival
            var entity = _dbContext.Festivals.First(t => t.Id == id);
            _dbContext.Remove(entity);

            _dbContext.SaveChanges();

        }
    }
}
