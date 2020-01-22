using System.Collections;


namespace My_Data_Structures.Data_Structures
{
    public class My_Array_List<T> : IEnumerable
    {
        private T[] list;
        private const int default_size = 256;
        public int NumberOfElements { get; private set; }


        public My_Array_List()
        {
            list = new T[default_size];
            NumberOfElements = 0;         
        }

        public My_Array_List(int size)
        {
            list = new T[size];
            NumberOfElements = 0;     
        }

        public My_Array_List(T [] initial)
        {
            list = initial ?? new T[default_size];                  
            NumberOfElements = initial != null ? GetNumOfElements(initial) : 0;                          
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
            list[NumberOfElements] = newElement;
            NumberOfElements++;

            if (NumberOfElements > (list.Length-1) / 2)            
                Resize();         
        }

        public bool Remove(T elementToRemove)
        {               
            for (int i = 0; i < NumberOfElements; i++)
            {
                
                if (list[i].Equals(elementToRemove) && (i!=NumberOfElements-1))
                {
                    for (int j = i; j < NumberOfElements; j++)
                    {
                        list[j] = list[j + 1];
                        NumberOfElements--;
                        if (NumberOfElements < (list.Length - 1) / 4)
                            Resize();
                    }                    
                    return true;
                }
                else if (list[i].Equals(elementToRemove) && (i == NumberOfElements - 1))
                {
                    list[i] = default(T);
                    NumberOfElements--;
                    if (NumberOfElements < (list.Length - 1) / 4)
                        Resize();
                    return true;
                }
            }
            return false;
        }

        public T Find(T target)
        {
            for (int i = 0; i < NumberOfElements; i++)
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
            T[] newList;
            if (NumberOfElements < list.Length/4)
            {
                newList = new T[list.Length/2];
                list.CopyTo(newList, 0);
                list = newList;
            }
            else
            {
                newList = new T[list.Length * 2];
                list.CopyTo(newList, 0);
                list = newList;
            }                 
        }      
    }
}
