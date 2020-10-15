using System.Collections.Generic;

namespace Bakery.Services
{
    public interface IRepository<IEntity>
    {
        IEnumerable<IEntity> Get();
        IEntity Get(int id);
        void Add(IEntity entity);
        void Delete(int id);
        void Update(int id, IEntity entity);
    }
}
