using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Data_Structures.Data_Structures
{
    public class MyStack<T>
    {
        private T[] stack;
        private const int default_size = 128;
        public int Number_of_elements { get; private set; }

        public MyStack()
        {
            stack = new T[default_size];
            Number_of_elements = 0;
        }

        public MyStack(int stackSize)
        {
            stack = new T[stackSize];
            Number_of_elements = 0;
        }

        public MyStack(MyStack<T> otherStack)
        {
            this.stack = otherStack?.stack ?? new T[default_size];
            this.Number_of_elements = otherStack?.Number_of_elements ?? 0;
        }

        public void Push(T newItem)
        {
            stack[Number_of_elements] = newItem;
            Number_of_elements++;

            if (Number_of_elements > stack.Length/2)
            {
                ResizeStack();
            }
        }

        public T Pop()
        {
            T top = stack[Number_of_elements - 1];
            stack[Number_of_elements - 1] = default(T);
            Number_of_elements--;
            return top;
        }

        private void ResizeStack()
        {
            if (Number_of_elements > stack.Length/2)
            {
                T[] new_stack = new T[stack.Length * 2];
                stack.CopyTo(new_stack,0);
                stack = new_stack;
            }
            else
            {
                T[] new_stack = new T[stack.Length/4];
                stack.CopyTo(new_stack, 0);
                stack = new_stack;
            }
        }
    }
}
