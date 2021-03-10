using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FestivalProject.DAL.Repositories
{
    public class ReservationRepository : IGenericCrudOperations<ReservationEntity>
    {
        private readonly FestivalDbContext _dbContext;

        public ReservationRepository(FestivalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<ReservationEntity> GetAll()
        {
            return _dbContext.Reservations.AsNoTracking()
                .Include(x => x.Festival)
                .Include(x => x.User)
                .ToList();
        }

        public ReservationEntity GetById(Guid id)
        {
            return _dbContext.Reservations.AsNoTracking()
                .Include(x => x.Festival)
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public int GetTicketsCountByFestivalId(Guid id)
        {
            var listOfReservations =_dbContext.Reservations.AsNoTracking().Where(x => x.FestivalId == id).ToList();
            var allTickets = 0;

            foreach (var item in listOfReservations)
            {
                allTickets += item.Tickets;
            }
                
            return allTickets;

        }


        public ReservationEntity Create(ReservationEntity item)
        {
            _dbContext.Reservations.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public ReservationEntity Update(ReservationEntity item)
        {
            _dbContext.Reservations.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.Reservations.AsNoTracking().First(t => t.Id == id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
