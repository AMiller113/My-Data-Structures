using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Data_Structures.Data_Structures
{
    class MyDeque<T>
    {
        private LinkedList<T> deque;
        public int size { get; private set; }

        public MyDeque()
        {
            deque = new LinkedList<T>();
        }

        public void EnqueueLast(T value)
        {
            deque.AddLast(value);
        }

        public void EnqueueFirst(T value)
        {
            deque.AddFirst(value);
        }

        public T DequeueFirst()
        {
            try
            {
                var value = deque.First.Value;
                deque.RemoveFirst();
                return value;
            }
            catch (InvalidOperationException e)
            {
                Console.Write(e.StackTrace);
                return default(T);
            }
        }

        public T DequeueLast()
        {
            try
            {
                var value = deque.Last.Value;
                deque.RemoveLast();
                return value;
            }
            catch (InvalidOperationException e)
            {
                Console.Write(e.StackTrace);
                return default(T);
            }
        }

        public bool RemoveFromDeque(T value)
        {
            return deque.Remove(value);
        }

        public T First()
        {
            var val = this.Empty() ? default(T) : deque.First.Value;
            return val;
        }

        public T Last()
        {
            var val = this.Empty() ? default(T) : deque.Last.Value;
            return val;
        }

        public bool Empty()
        {
            return (deque.Count == 0);
        }
    }
}
