using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Entities;

namespace FestivalProject.DAL.Interfaces
{
    public interface IGenericBindingTablesOperations<T> where T : EntityBase
    {
        T Create(T item);
        T Update(T item);

    }
}
