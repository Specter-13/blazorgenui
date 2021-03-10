using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FestivalProject.DAL.Repositories
{
    public class InterpretRepository : IGenericCrudOperations<InterpretEntity>
    {
        private readonly FestivalDbContext _dbContext;

        public InterpretRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<InterpretEntity> GetAll()
        {
            return _dbContext.Interprets
                .Include(x => x.FestivalInterpret)
                .Include(x => x.MemberList)
                .Include(x => x.StageInterpret)
                .ToList();
        }

        public InterpretEntity GetById(Guid id)
        {
            return _dbContext.Interprets.Include(x => x.MemberList)
                .Include(x => x.FestivalInterpret)
                .ThenInclude(x => x.Festival)
                .Include(x => x.StageInterpret)
                .ThenInclude(x => x.Stage)
                .FirstOrDefault(x => x.Id == id);
        }

        public InterpretEntity Create(InterpretEntity item)
        {
            _dbContext.Interprets.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public InterpretEntity Update(InterpretEntity item)
        {
            _dbContext.Interprets.Update(item);
            _dbContext.SaveChanges();
            return item;
        }


        public void Delete(Guid id)
        {
            //remove members
            _dbContext.Members
                .RemoveRange(_dbContext.Members.Where((x => x.InterpretId == id)));

            //remove festivalInterpret
            _dbContext.FestivalInterprets
                .RemoveRange(_dbContext.FestivalInterprets.Where((x => x.InterpretId == id)));
            //remove stageInterpret
            _dbContext.StageInterprets
                .RemoveRange(_dbContext.StageInterprets.Where((x => x.InterpretId == id)));
            //remove interpret
            var entity = _dbContext.Interprets.First(t => t.Id == id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
