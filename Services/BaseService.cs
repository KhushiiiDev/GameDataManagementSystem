using GameDataManagementSystem.Models;
using GameDataManagementSystem.Interfaces;

namespace GameDataManagementSystem.Services
{
    public abstract class BaseService<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly List<T> collection;

        protected BaseService(List<T> data)
        {
            collection = data;
        }

        public IEnumerable<T> GetAll() => collection;
        public T GetById(int id) => collection.FirstOrDefault(x => x.Id == id);

        public void Add(T item)
        {
            item.Id = GetNextId();
            collection.Add(item);
        }

        public void Update(T item)
        {
            var index = collection.FindIndex(x => x.Id == item.Id);
            if (index >= 0) collection[index] = item;
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null) collection.Remove(existing);
        }

        public int GetNextId() => collection.Count == 0 ? 1 : collection.Max(x => x.Id) + 1;
    }
}