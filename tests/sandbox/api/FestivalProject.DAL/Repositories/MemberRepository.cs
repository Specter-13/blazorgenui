using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;

namespace FestivalProject.DAL.Repositories
{
    public class MemberRepository : IGenericCrudOperations<MemberEntity>
    {
        private readonly FestivalDbContext _dbContext;

        public MemberRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<MemberEntity> GetAll()
        {
            return _dbContext.Members.ToList();
        }

        public MemberEntity GetById(Guid id)
        {
            return _dbContext.Members.First(x => x.Id == id);
        }

        public MemberEntity Create(MemberEntity item)
        {
            _dbContext.Members.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public MemberEntity Update(MemberEntity item)
        {
            _dbContext.Members.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.Members.First(t => t.Id == id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
