using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Data_Structures.Data_Structures
{
    public class MyLinkedList<T>
    {
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }
        public int Size { get; private set; }

        public MyLinkedList()
        {

        }

        public MyLinkedList(T[] initialValues)
        {
            foreach (var val in initialValues)
            {
                this.Insert(val);
            }
        }

        public Node<T> Find(T value)
        {
            if (Size == 0) return null;

            var currentNode = Head.Next;
            while (!currentNode.Equals(Tail))
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentNode;
                }
                currentNode = currentNode.Next;
            }
            return null;
        }

        public List<Node<T>> FindAll(T value)
        {
            List<Node<T>> list = new List<Node<T>>();

            if (Size == 0) return null;

            var currentNode = Head.Next;
            while (!currentNode.Equals(Tail))
            {
                if (currentNode.Value.Equals(value))
                {
                    list.Add(currentNode);
                }
                currentNode = currentNode.Next;
            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        public void Insert(T newValue)
        {
            if (Head.Next.Equals(null))
            {
                Head.Next = new Node<T>(newValue, Tail, Head);
                Tail.Previous = Head.Next;
                Size++;
            }
            else
            {
                Tail.Previous.Next = new Node<T>(newValue, Tail, Tail.Previous);
                Tail.Previous = Tail.Previous.Next;
                Size++;
            }
        }

        public bool Delete(T value)
        {
           if (Size == 0) return false;

           var currentNode = Head.Next;

            while (!currentNode.Equals(Tail))
            {
                if (currentNode.Value.Equals(value))
                {
                    currentNode.Previous.Next = currentNode.Next;
                    currentNode.Next.Previous = currentNode.Previous;
                    Size--;
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public bool DeleteAll(T value)
        {
            int cur_size = Size;
            if (Size == 0) return false;

            var currentNode = Head.Next;

            while (!currentNode.Equals(Tail))
            {
                if (currentNode.Value.Equals(value))
                {
                    currentNode.Previous.Next = currentNode.Next;
                    currentNode.Next.Previous = currentNode.Previous;
                    Size--;
                }
                currentNode = currentNode.Next;
            }

            bool anyDeleted = !((cur_size - Size) == 0);
            return anyDeleted;
        }   
    }
    public class Node<U>
    {
        public Node(U value, Node<U> next, Node<U> previous)
        {
            this.Value = value;
            this.Next = next;
            this.Previous = previous;
        }

        public U Value { get; set; }
        public Node<U> Next { get; set; }
        public Node<U> Previous { get; set; }
    }
}
