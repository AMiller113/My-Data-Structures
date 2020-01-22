using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Data_Structures.Data_Structures
{
    class MyQueue<T>
    {
        private LinkedList<T> queue;
        public int size { get; private set; }

        public MyQueue()
        {
            queue = new LinkedList<T>();
        }

        public void Enqueue(T value)
        {
            queue.AddLast(value);
        }

        public T Dequeue()
        {
            try
            {
                var value = queue.First.Value;
                queue.RemoveFirst();
                return value;
            }
            catch (InvalidOperationException e)
            {
                Console.Write(e.StackTrace);
                return default(T);
            }         
        }

        public bool RemoveFromQueue(T value)
        {
           return queue.Remove(value);
        }

        public T First()
        {
            return queue.First.Value;
        }

        public bool Empty()
        {
            return (queue.Count == 0);
        }
    }
}
