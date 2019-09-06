using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueTask
{
    public class Queue<T> : IEnumerator<T>, IEnumerable<T>
    {
        LinkedList<T> _items = new LinkedList<T>();

        /// <summary>
        /// Pointer to the current position of the element in the array.
        /// </summary>
        int position = -1;

        // Свойство хранит в себе количество элементов очереди
        /// <summary>
        /// The property stores the number of queue elements.
        /// </summary>
        public int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// The method adds a new item to the top of the queue.
        /// </summary>
        /// <param name="value"></param>
        public void EnqueueFirst(T value)
        {
            _items.AddFirst(value);
        }

        /// <summary>
        /// The method adds a new item to the end of the queue.
        /// </summary>
        /// <param name="value"></param>
        public void EnqueueLast(T value)
        {
            _items.AddLast(value);
        }

        /// <summary>
        /// The method removes the first element from the queue.
        /// </summary>
        /// <returns></returns>
        public T DequeueFirst()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Очередь пуста");
            }

            T temp = _items.First.Value;
            _items.RemoveFirst();

            return temp;
        }

        /// <summary>
        /// The method removes the last item from the queue.
        /// </summary>
        /// <returns></returns>
        public T DequeueLast()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Очередь пуста"); //!!!!!
            }

            T temp = _items.Last.Value;
            _items.RemoveLast();
            return temp;
        }

        /// <summary>
        /// Метод возвращает первый элемент очереди.
        /// </summary>
        /// <returns></returns>
        public T PeekFirst()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Очередь пуста");
            }

            return _items.First.Value;
        }

        /// <summary>
        /// The method returns the last element of the queue.
        /// </summary>
        /// <returns></returns>
        public T PeekLast()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Очередь пуста");
            }
            return _items.Last.Value;
        }

        /// <summary>
        /// Move the internal pointer (position) one position.
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (position < _items.Count - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Set the pointer (position) before dialing.
        /// </summary>
        public void Reset()
        {
            position = -1;
        }

        /// <summary>
        /// Get the current item in the set.
        /// </summary>
        public T Current
        {
            get
            {
                T[] array = new T[_items.Count];
                _items.CopyTo(array, 0);
                return array[position];
            }
        }

        /// <summary>
        /// Get the current item in the set.
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                T[] array = new T[_items.Count];
                _items.CopyTo(array, 0);
                return array[position];
            }
        }

        public void Dispose()
        {
            Reset();
        }

        /// <summary>
        /// The implementation of the interface is IEnumerable.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this as IEnumerator<T>;
        }

        /// <summary>
        /// The implementation of the interface is IEnumerable.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }
    }
}