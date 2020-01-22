using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Data_Structures.Data_Structures
{
    class HeapNode<U>
    {
        public HeapNode(int key, U value)
        {
            Key = key;
            Value = value;
        }
    
        public int Key { get; }
        public U Value { get; set; }
    }
    class BinaryHeap<T>
    {
        HeapNode<T>[] binary_heap;
        private static int default_capacity = 512;       
        public int size { get; private set; }


        public BinaryHeap()
        {
            binary_heap = new HeapNode<T>[default_capacity];
            size = 0;
        }

        public BinaryHeap(T[] values)
        {
            foreach(var value in values)
            {
                Insert(value);
            }
        }

        public void Insert(T value)
        {
            binary_heap[size] = new HeapNode<T>(size, value); // Insert to the last current node
            size++;
            BubbleUp(size - 1); // Bubble up to correct location
        }

        public T GetMin()
        {
            if (size == 0)
            {
                return default(T);
            }
            return binary_heap[0].Value;
        }

        public T ExtractMin()
        {
            if (size == 0)
            {
                return default(T);
            }

            var value = binary_heap[0].Value;
            Heapify();
            return value;
        }

        public void Heapify()
        {                   
            binary_heap[0] = binary_heap[size - 1];
            binary_heap[size - 1] = default(HeapNode<T>);
            int currentIndex = 0;
            while ((binary_heap[currentIndex].Key > binary_heap[2 * currentIndex + 1].Key) ||
                (binary_heap[currentIndex].Key > binary_heap[2 * currentIndex + 2].Key))
            {
                int lowerIndex = (binary_heap[2 * currentIndex + 1].Key) > binary_heap[2 * currentIndex + 2].Key ? (2 * currentIndex + 2) : (2 * currentIndex + 1);
                Swap(currentIndex, lowerIndex);
            }
        }

       
        private void BubbleUp(int index)
        {
            if (size < 2)
            {
                return;
            }
            int parentIndex = (index - 1) / 2;
            while (binary_heap[parentIndex].Key > binary_heap[index].Key)
            {
                Swap(parentIndex, index);
                if (parentIndex > 0)
                {
                    index = parentIndex;
                    parentIndex = (index - 1) / 2;
                }                   
            }
        }
       
        public void Swap(int i1,int i2)
        {
            var temp = binary_heap[i1];
            binary_heap[i1] = binary_heap[i2];
            binary_heap[i2] = temp;
        }
    }
}
