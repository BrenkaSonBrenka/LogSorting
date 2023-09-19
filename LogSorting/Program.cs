using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSorting
{
    class Program
    {
        static void Main()
        {
            int[] initial = { 4, 9, 1, 7, 5, 6, 2, 8, 12, 10 };
            Console.WriteLine("Начальный массив");
            for (int i = 0; i < initial.Length; i++)
            {
                Console.Write(" {0}", initial[i]);
            }
            int[] qsort = QSortArray(initial, 0, initial.Length - 1);
            Console.WriteLine("\nМассив, сортированный быстрой сортировкой");
            for (int i = 0; i < qsort.Length; i++)
            {
                Console.Write(" {0}", qsort[i]);
            }
            int[] mergesort = MergeSortArray(initial, 0, initial.Length - 1);
            Console.WriteLine("\nМассив, сортированный сортировкой Мерге");
            for (int i = 0; i < mergesort.Length; i++)
            {
                Console.Write($" {mergesort[i]}");
            }

            Console.ReadLine();
        }
        public static int[] QSortArray(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var arr = array[leftIndex];

            while (i <= j)
            {
                while (array[i] < arr)
                {
                    i++;
                }

                while (array[j] > arr)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QSortArray(array, leftIndex, j);

            if (i < rightIndex)
                QSortArray(array, i, rightIndex);

            return array;
        }
        public static int[] MergeSortArray(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middle = leftIndex + (rightIndex - leftIndex) / 2;

                MergeSortArray(array, leftIndex, middle);
                MergeSortArray(array, middle + 1, rightIndex);

                MergeArray(array, leftIndex, middle, rightIndex);
            }

            return array;
        }
        public static void MergeArray(int[] array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i, j;

            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middle + 1 + j];

            i = 0;
            j = 0;
            int k = left;

            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }

            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }

            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }
    }
}
