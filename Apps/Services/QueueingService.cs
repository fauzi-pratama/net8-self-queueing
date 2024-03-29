﻿
using System.Collections.Concurrent;

namespace Apps.Services
{
    public interface IQueueingService<T>
    {
        void Enqueue(T item);
        T Dequeue();
    }

    public class QueueingService<T> : IQueueingService<T> where T : class
    {
        private readonly ConcurrentQueue<T> _items = new();

        public void Enqueue(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            _items.Enqueue(item);
        }
        public T Dequeue()
        {
            var success = _items.TryDequeue(out var workItem);

            return success ? workItem : null;
        }
    }
}
