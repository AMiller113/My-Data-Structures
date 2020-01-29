using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
   static class SortingAlgorithms<T> where T: IComparable
    {
        public static List<T> SelectionSort(List<T> unsortedList)
        {
            if (unsortedList.Count < 2)
            {
                return unsortedList;
            }
            List<T> sortedList = new List<T>();
            while (sortedList.Count < unsortedList.Count)
            {
                T min = unsortedList[0];
                foreach(T item in unsortedList)
                {                 
                    if (min.CompareTo(item) > 0)
                    {
                        min = item;
                    }
                }
                sortedList.Add(min);
                unsortedList.Remove(min);
            }
            return sortedList;
        }

        public static T[] SelectionSort(T[] unsortedList)
        {
            if (unsortedList.Length < 2)
            {
                return unsortedList;
            }

            T[] sortedList = new T[unsortedList.Length];
            int i = 0;
            while (unsortedList.Length > i)
            {
                if (unsortedList[0].Equals(null))
                {
                    i++;
                    continue;
                }
                T min = unsortedList[0];
                int min_index = 0;
                for (int j = 0; j < unsortedList.Length; j++)
                {
                    if (unsortedList[j].Equals(null))
                    {                      
                        continue;
                    }
                    if (min.CompareTo(unsortedList[j]) > 0)
                    {
                        min = unsortedList[j];
                        min_index = j;
                    }
                }
                sortedList[i] = min;
                for (int j = min_index; j + 1 < unsortedList.Length; j++)
                {
                    unsortedList[j] = unsortedList[j + 1];
                }
                Array.Copy(unsortedList, unsortedList, unsortedList.Length - 1);
                i++;
            }
            return sortedList;
        }

        public static List<T> InsertionSort(List<T> list)
        {
            if(list.Count < 2)
            {
                return list;
            }
            int i = 1, j;
            T key;
            while (i < list.Count)
            {
                if (list[i].Equals(null))
                {
                    i++;
                    continue;
                }
                j = i - 1;
                key = list[i];
                while (j >=0 && list[i].CompareTo(key) > 0)
                {
                    list[j+1] = list[j];
                    j--;
                }
                list[j + 1] = key;
                i++;
            }
            return list;
        }

        public static T[] InsertionSort(T[] list)
        {
            if (list.Length < 2)
            {
                return list;
            }
            int i = 1, j;
            T key;
            while (i < list.Length)
            {
                if (list[i].Equals(null))
                {
                    i++;
                    continue;
                }
                j = i - 1;
                key = list[i];
                while (j >= 0 && list[i].CompareTo(key) > 0)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = key;
                i++;
            }
            return list;
        }

        public static void MergeSort(ref List<T> list, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                var listArr = list.ToArray();
                int mid = (leftIndex + rightIndex) / 2;
                MergeSort(ref listArr, leftIndex, mid);
                MergeSort(ref listArr, mid + 1, rightIndex);
                Merge(ref list,ref listArr, leftIndex, rightIndex, mid);
            }
        }

        public static void MergeSort(ref T[] list, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int mid = (leftIndex + rightIndex) / 2;
                MergeSort(ref list, leftIndex, mid);
                MergeSort(ref list, mid+1, rightIndex);
                Merge(ref list, leftIndex, rightIndex, mid);
            }          
        }

        private static void Merge(ref List<T> originalList, ref T[] list, int leftIndex, int rightIndex, int midPoint)
        {
            int leftSize = midPoint - leftIndex + 1, rightSize = rightIndex - midPoint;
            T[] leftSubarray = new T[leftSize];
            T[] rightSubarray = new T[rightSize];
            for (int i = 0; i < leftSize; i++)
                leftSubarray[i] = list[leftIndex + i];
            for (int i = 0; i < rightSize; i++)
                rightSubarray[i] = list[midPoint + 1 + i];
            int j = 0;
            int f = 0;
            int k = leftIndex;
            while (f < leftSize && j < rightSize)
            {
                if (leftSubarray[f].CompareTo(rightSubarray[j]) <= 0)
                    list[k++] = leftSubarray[f++];
                else
                    list[k++] = rightSubarray[j++];
            }
            while (f < leftSize)
            {
                list[k++] = leftSubarray[f++];
            }

            while (j < rightSize)
            {
                list[k++] = rightSubarray[j++];
            }
            originalList = list.ToList();
        }

        private static void Merge(ref T[] list, int leftIndex, int rightIndex, int midPoint)
        {
            int leftSize = midPoint - leftIndex + 1, rightSize = rightIndex - midPoint;
            T[] leftSubarray = new T[leftSize];
            T[] rightSubarray = new T[rightSize];
            for (int i = 0; i < leftSize; i++)
                leftSubarray[i] = list[leftIndex + i];           
            for (int i = 0; i < rightSize; i++)
                rightSubarray[i] = list[midPoint + 1 + i];            
           int j = 0;
           int f = 0;
           int k = leftIndex;
           while (f < leftSize && j < rightSize)
            {
               if (leftSubarray[f].CompareTo(rightSubarray[j]) <= 0)
                   list[k++] = leftSubarray[f++];
               else
                   list[k++] = rightSubarray[j++];               
            }
            while (f < leftSize)
            {
                list[k++] = leftSubarray[f++];
            }

            while (j < rightSize)
            {
                list[k++] = rightSubarray[j++];
            }
        }

        public static void QuickSort(ref List<T> list)
        {
            if (list.Count < 2)
            {
                return;
            }
            Random random = new Random();
            int pivotIndex = random.Next(list.Count);
            List<T> lesser = new List<T>();
            List<T> greater = new List<T>();
            List<T> equal = new List<T>(); 

            foreach(var value in list)
            {
                if (value.CompareTo(list[pivotIndex]) < 0)
                {
                    lesser.Add(value);
                }
                else if (value.CompareTo(list[pivotIndex]) > 0)
                {
                    greater.Add(value);
                }
                else
                {
                    equal.Add(value);
                }   
            }
            QuickSort(ref lesser);
            QuickSort(ref greater);
            list.Clear();
            foreach (var value in lesser)
            {
                list.Add(value);
            }
            foreach (var value in equal)
            {
                list.Add(value);
            }
            foreach (var value in greater)
            {
                list.Add(value);
            }
        }

        public static void QuickSort(ref T[] list)
        {
            if (list.Length < 2)
            {
                return;
            }

            Random random = new Random();
            int pivotIndex = random.Next(list.Length);
            List<T> lesser = new List<T>();
            List<T> greater = new List<T>();
            List<T> equal = new List<T>();
            foreach (var value in list)
            {
                if (value.CompareTo(list[pivotIndex]) < 0)
                {
                    lesser.Add(value);
                }
                else if (value.CompareTo(list[pivotIndex]) > 0)
                {
                    greater.Add(value);
                }
                else
                {
                    equal.Add(value);
                }
            }
            T[] lesserArr = lesser.ToArray();
            T[] greaterArr = greater.ToArray();
            QuickSort(ref lesserArr);
            QuickSort(ref greaterArr);
            int l = 0;
            list = new T[lesser.Count + greater.Count + equal.Count];
            foreach (var value in lesserArr)
            {
                list[l++] = value;
            }
            foreach (var value in equal)
            {
                list[l++] = value;
            }
            foreach (var value in greaterArr)
            {
                list[l++] = value;
            }
        }
    }
}
