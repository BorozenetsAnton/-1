using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp2
{
    class Serchclass
    {
        public static Student Liniersearch(List<Student> list,int key,ref int compare)
        {
            for(int i=0;i<list.Count;i++)
            {
                compare++;
                if (list[i].Number == key)
                    return list[i];
            }
            return null;
        }

        public static Student Liniersearch(List<Student> list, int key)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Number == key)
                    return list[i];
            }
            return null;
        }

        public static Student BinarySearch(Student[] a, int x,ref int compare)
        {
            
            compare += 3;
            if ((a.Length == 0) || (x < a[0].Number) || (x > a[a.Length - 1].Number))
                return null;

            int first = 0;
            int last = a.Length;

            while (first < last)
            {
                int mid = first + (last - first) / 2;
                compare++;
                if (x <= a[mid].Number)
                    last = mid;
                else
                    first = mid + 1;
            }

            compare++;
            if (a[last].Number == x)
                return a[last];
            else
                return null;
        }

        public static Student Interpolserch(Student[] a,int key,ref int compare)
        {
            int low = 0;
            int high = a.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (key < a[mid].Number)
                {
                    high = mid - 1;
                    compare++;
                }
                else if (key > a[mid].Number)
                {
                    low = mid + 1;
                    compare++;
                }
                else if (key == a[mid].Number)
                {
                    compare++;
                    return a[mid];
                }
            }
            return null;
        }

        public static int min(int x, int y)
        {
            return (x <= y) ? x : y;
        }

        public static Student fibMonaccianSearch(Student[] arr ,int x, int n, ref int compare)
        {
            int fibMMm2 = 0; 
            int fibMMm1 = 1; 
            int fibM = fibMMm2 + fibMMm1;

            while (fibM < n)
            {
                fibMMm2 = fibMMm1;
                fibMMm1 = fibM;
                fibM = fibMMm2 + fibMMm1;
            }

            int offset = -1;

            while (fibM > 1)
            {
                int i = min(offset + fibMMm2, n - 1);
                if (arr[i].Number < x)
                {
                    fibM = fibMMm1;
                    fibMMm1 = fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                    offset = i;
                    compare++;

                }

                else if (arr[i].Number > x)
                {
                    fibM = fibMMm2;
                    fibMMm1 = fibMMm1 - fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                    compare++;

                }

                else return arr[i];
            }

            if (fibMMm1 == 1 && arr[offset + 1].Number == x)
                return arr[offset + 1];

            return null;
        }

        public static Student exponentialSearch(Student[] arr,
                         int n, int x, ref int compare)
        {
            if (arr[0].Number == x)
                return arr[0];
            compare++;
            int i = 1;
            while (i < n && arr[i].Number <= x)
                i = i * 2;
            return binarySearch(arr, i / 2,
                               Math.Min(i, n), x, ref compare);
        }

        static Student binarySearch(Student[] arr, int l,
                        int r, int x, ref int compare)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                if (arr[mid].Number == x)
                {
                    compare++;
                    return arr[mid];

                }
                if (arr[mid].Number > x)
                {
                    compare++;
                    return binarySearch(arr, l, mid - 1, x, ref compare);
                }

                return binarySearch(arr, mid + 1, r, x,ref compare);
            }

            return null;
        }
    }
}
