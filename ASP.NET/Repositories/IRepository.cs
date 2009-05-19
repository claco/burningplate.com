using System;
using System.Linq;

namespace BurningPlate.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T GetById(Guid id);
    }
}