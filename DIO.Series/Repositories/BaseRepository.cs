using System.Collections.Generic;
using System.Linq;
using DIO.Series.Interfaces;
using DIO.Series.Models;

namespace DIO.Series.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T, int> where T: BaseModel
    {
        private readonly List<T> _items;

        public BaseRepository()
        {
            _items = new List<T>();
        }

        public void Create(T model)
        {
            model.Id = _items.Count;
            
            _items.Add(model);
        }

        public void Delete(int id)
        {
            var index = _items.FindIndex(x => x.Id.Equals(id));

            if (index > -1)
            {
                _items[index].Deleted = true;
            }
        }

        public T Find(int id)
        {
            return _items.Find(x => x.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return _items.Where(x => !x.Deleted).ToList();
        }

        public void Update(int id, T model)
        {
            var index = _items.FindIndex(x => x.Id.Equals(id));

            if (index > -1)
            {
                _items[index] = model;
            }
        }
    }
}