using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoodStore.Domain.Entity;

namespace WoodStore.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);

        Task<T> Get(int id);

        Task<List<T>> Select();

        Task<bool> Delete(T entity);
    }
}
