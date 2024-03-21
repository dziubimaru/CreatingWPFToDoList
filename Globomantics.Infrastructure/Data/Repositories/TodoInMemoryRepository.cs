using Globomantics.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Repositories
{
    public class TodoInMemoryRepository<T> : IRepository<T>
        where T : Todo
    {
        private ConcurrentDictionary<Guid, T> Items { get; } = new();
        public Task AddAsync(T item)
        {
            Items.TryAdd(item.Id, item);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<T>> AllAsync()
        {
            var items = Items.Values.ToArray();
            return Task.FromResult<IEnumerable<T>>(items);
        }

        public Task<T> FindByAsync(string value)
        {
            var result = Items.Values.First(item => item.Title == value);
            return Task.FromResult(result);
        }

        public Task<T> GetAsync(Guid id)
        {
            return Task.FromResult(Items[id]);
        }

        public Task SaveChangeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
