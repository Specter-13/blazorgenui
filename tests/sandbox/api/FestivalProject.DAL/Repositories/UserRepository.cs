using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FestivalProject.DAL.Repositories
{
    public class UserRepository : IGenericCrudOperations<UserEntity>
    {
        private readonly FestivalDbContext _dbContext;

        public UserRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<UserEntity> GetAll()
        {
            var fds =_dbContext.Users.ToList();
            return _dbContext.Users.ToList();
        }

        public UserEntity GetById(Guid id)
        {
            return _dbContext.Users.Include(x => x.ReservationList)
                .ThenInclude(x => x.Festival)
                .FirstOrDefault(x => x.Id == id);
        }

        public UserEntity GetByUsername(string username)
        {
            return _dbContext.Users.Include(x => x.ReservationList)
                .ThenInclude(x => x.Festival)
                .FirstOrDefault(x => x.Username == username);
        }

        public UserEntity Create(UserEntity item)
        {
            if (item.Username != null)
            {
                var returnedItem = _dbContext.Users.FirstOrDefault(x => x.Username == item.Username);
                if (returnedItem != null)
                {
                    return null;
                }
            }

            _dbContext.Users.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public UserEntity Update(UserEntity item)
        {
            _dbContext.Users.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {
            //remove all depended reservations
            _dbContext.Reservations
                .RemoveRange(_dbContext.Reservations.Where((x => x.UserId == id)));

            //remove user
            var entity = _dbContext.Users.First(t => t.Id == id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
