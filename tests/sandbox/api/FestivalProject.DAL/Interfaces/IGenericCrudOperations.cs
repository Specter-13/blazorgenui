using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.DAL.Interfaces
{
    public interface IGenericCrudOperations<T> where T : EntityBase
    {
        IList<T> GetAll();
        T GetById(Guid id);
        T Create(T item);
        T Update(T item);
        void Delete(Guid id);
    }
}
