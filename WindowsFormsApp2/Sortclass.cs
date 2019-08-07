using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp2
{
    class Sortclass
    {
        public static void gnomsort (List<Student> lst,out int numbere,out int numberc)
        {
            int i = 1;
            int j = 2;
            int nume = 0,numc = 0;
            while (i < lst.Count)
            {
                if (lst[i - 1].Number <= lst[i].Number)
                {
                    i = j;
                    j++;
                    nume++;
                }
                else
                {
                    Student b = lst[i - 1];
                    lst[i - 1] = lst[i];
                    lst[i] = b;
                    numc++;
                    i--;
                    if (i == 0)
                    {
                        i = j;
                        j++;
                        nume++;
                    }
                }
            }
            numberc = numc;
            numbere = nume;
        }

        static int partition(Student[] array, int start, int end,ref int compare,ref int swaps)
        {
            Student temp;
            
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                compare++;
                if (array[i].Number < array[end].Number)
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                    swaps++;
                }
            }
            //pivot - средний
            swaps++;
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            
            return marker;
        }

        public static void quicksort(Student[] array, int start, int end,ref int compare,ref int swaps)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end, ref compare, ref swaps);
            quicksort(array, start, pivot - 1,ref compare,ref swaps);
            quicksort(array, pivot + 1, end, ref compare, ref swaps);
        }

        static Int32 add2pyramid(Student[] arr, Int32 i, Int32 N,ref int swaps,ref int compare)
        {
            Int32 imax;
            Student buf;
            if ((2 * i + 2) < N)
            {
                compare++;
                if (arr[2 * i + 1].Number < arr[2 * i + 2].Number) { imax = 2 * i + 2;compare++; }
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) { compare++; return i; }
            if (arr[i].Number < arr[imax].Number)
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                compare++;
                swaps++;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

        public static void Pyramid_Sort(Student[] arr, Int32 len,ref int compare,ref int swaps)
        {
            // building the pyramid
            for (Int32 i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len,ref swaps,ref compare);
                if (prev_i != i) ++i;
            }

            //sorting
            Student buf;
            for (Int32 k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                swaps++;
                Int32 i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k,ref swaps,ref compare);
                }
            }
        }

        public static void Cocktailsort(Student[] name,ref int compare,ref int swaps)
        {
            Student b = new Student();
            int k = 0;
            int left = 0;
            int right = name.Length - 1;
            while (left < right)
            {
                compare++;
                for (int i = left; i < right; i++)
                {
                    compare++;
                    if (name[i].Number > name[i + 1].Number)
                    {
                        b = name[i];
                        name[i] = name[i + 1];
                        name[i + 1] = b;
                        swaps++;
                        k = i;
                    }
                }
                right = k;
                compare++;
                if (left >= right) break;
                for (int i = right; i > left; i--)
                {
                    compare++;
                    if (name[i - 1].Number > name[i].Number)
                    {
                        b = name[i];
                        name[i] = name[i - 1];
                        name[i - 1] = b;
                        k = i;
                        swaps++;
                    }
                }
                left = k;
            }
        }

        public static void BubbleSort(Student[] A,ref int compare,ref int swaps)
        {
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A.Length - 1; j++)
                {
                    compare++;
                    if (A[j].Number > A[j + 1].Number)
                    {
                        swaps++;
                        Student temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
                }
            }
        }
        
    }
}
