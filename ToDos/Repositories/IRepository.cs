using System.Collections.Generic;

namespace ToDos.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetCollection(object collectionID);

        T Get(object entityID);
    }
}
