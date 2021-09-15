using System.Collections.Generic;
using DIO.Series.Models;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T, K> where T: BaseModel
    {
        void Create(T model);

        T Find(K id);

        List<T> FindAll();

        void Update(K id, T model);

        void Delete(K id);
    }
}