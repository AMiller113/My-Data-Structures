using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Data_Structures.Data_Structures
{
    public class My_Array_List<T> : IEnumerable
    {
        private T[] list;
        private int number_of_elements;
        private const int default_size = 256;       
        public int NumberOfElements { get => number_of_elements; }
   

        public My_Array_List()
        {
            list = new T[default_size];
            number_of_elements = 0;         
        }

        public My_Array_List(int size)
        {
            list = new T[size];
            number_of_elements = 0;     
        }

        public My_Array_List(T [] initial)
        {
            list = initial ?? new T[default_size];                  
            number_of_elements = initial != null ? GetNumOfElements(initial) : 0;                          
        }

        private int GetNumOfElements(T[] initial)
        {          
            for (int i = initial.Length - 1; i >= 0; i--)
            {
                if (initial[i]!=null)
                {
                     return i + 1;
                }
            }
            return 0;
        }

        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public T this[int index] { get => list[index]; set => list[index] = value; }

        public void Add(T newElement)
        {
            list[number_of_elements] = newElement;
            number_of_elements++;

            if (number_of_elements > (list.Length-1) / 2)            
                Resize();         
        }

        public bool Remove(T elementToRemove)
        {               
            for (int i = 0; i < number_of_elements; i++)
            {
                
                if (list[i].Equals(elementToRemove) && (i!=number_of_elements-1))
                {
                    for (int j = i; j < number_of_elements; j++)
                    {
                        list[j] = list[j + 1];                       
                    }                    
                    return true;
                }
                else if (list[i].Equals(elementToRemove) && (i == number_of_elements - 1))
                {
                    list[i] = default(T);
                    return true;
                }
            }
            return false;
        }

        public T Find(T target)
        {
            for (int i = 0; i < number_of_elements; i++)
            {
                if (list[i].Equals(target))
                {
                    return list[i];
                }
            }
            return default(T);
        }

        public My_Array_List<T> FindAll(T target)
        {
            My_Array_List<T> resultList = new My_Array_List<T>();

            foreach (var item in list)
            {
                if (item.Equals(target))
                {
                    resultList.Add(target);
                }
            }
            return resultList;
        }

        private void Resize()
        {
            T[] newList = new T[list.Length * 2];
            list.CopyTo(newList,0);
            list = newList;          
        }      
    }
}
