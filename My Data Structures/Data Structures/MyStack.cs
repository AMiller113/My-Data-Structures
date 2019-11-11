using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Data_Structures.Data_Structures
{
    public class MyStack
    {
        private int[] stack;
        private int number_of_elements;
        private const int default_size = 128;

        public MyStack()
        {
            stack = new int[default_size];
        }

        public MyStack(MyStack otherStack)
        {
            this.stack = otherStack.stack;

        }

        public int Number_of_elements { get => number_of_elements; }
    }
}
