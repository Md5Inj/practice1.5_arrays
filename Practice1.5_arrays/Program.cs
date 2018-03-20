using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1._5_arrays
{
    public class ReverseComparer : IComparer
    {
        public int Compare(Object x, Object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }
    }

    class Program
    {
        static void SetRandom(int[] a)
        {
            Random r = new Random();
            for (int i = 0; i  < a.Length; i ++)
            {
                a[i] = r.Next(-10, 10);
            }
        }

        static void SetRandom(double[] a)
        {
            Random r = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = r.Next(-10, 10) * 0.1;
            }
        }

        static void SetRandom(int[] a, int min, int max)
        {
            Random r = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = r.Next(min, max);
            }
        }

        static void SetRandom(int[,] a)
        {
            Random r = new Random();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = r.Next(-10, 10);
                }
            }
        }

        static void Print<T>(T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine();
        }

        static void Print<T>(T[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static int[] Task1(int[] a)
        {
            int[] res = new int[2];
            int razn = int.MaxValue, min = int.MaxValue, num1 = 0, num2 = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[i] != a[j])
                    {
                        razn = a[i] > a[j] ?  a[i] - a[j] : a[j] - a[i];
                        if (razn < min)
                        {
                            min = razn;
                            num1 = a[i];
                            num2 = a[j];
                        }

                    }
                }
            }
            res[0] = num1;
            res[1] = num2;
                
            return res;
        }

        static double Sum(double[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        static void Task3(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 5 == 0)
                    {
                        arr[i, j] = 0;
                    }
                    else if (arr[i, j] > 0 && j != arr.GetLength(1)-1)
                    {
                        arr[i, j] += arr[i, arr.GetLength(1)-1];
                    }
                    else if (arr[i, j] < 0 && j != arr.GetLength(1) - 1)
                    {
                        arr[i, j] += arr[i, 0];
                    }
                }
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        static int Find(int[] array, int num)
        {
            string a = Convert.ToString(num);
            string b;

            for (int i = 0; i < array.Length; i++)
            {
                if (num != array[i])
                {
                    b = Convert.ToString(array[i]);
                    if (a[a.Length-1] == b[0])
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        static void Task4(int[] array)
        {
            int now = 0, finded = 0;
            bool ok = false;
            while (!ok)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    finded = Find(array, array[i]);
                    if (finded != -1)
                    {
                        Swap(ref array[i], ref array[now]);
                        Swap(ref array[finded], ref array[now + 1]);
                        now++;
                    }
                    else ok = true;
                }
            }
        }

        static void Main(string[] args)
        {
            IComparer revComparer = new ReverseComparer();
            int[] intArr = new int[10];
            SetRandom(intArr);
            Print(intArr);
            int[] arr = Task1(intArr);
            Console.WriteLine($"{arr[0]} {arr[1]}");

            double[] doubleArr = new double[10];
            SetRandom(doubleArr);
            Print(doubleArr);
            double sum = Sum(doubleArr);
            if (sum > 0)
            {
                Console.WriteLine("Sum is positive");
                Array.Sort(doubleArr);
            }
            else
            {
                Console.WriteLine("Sum is negative");
                Array.Sort(doubleArr, revComparer);
            }
            Print(doubleArr);

            int[,] matr = new int[5, 5];
            SetRandom(matr);
            Print(matr);
            Task3(matr);
            Console.WriteLine("Task №3");
            Print(matr);

            int[] intArray2 = new int[30];
            SetRandom(intArray2, 10, 99);
            Print(intArray2);
            Task4(intArray2);
            Print(intArray2);

            Console.ReadKey();
        }
    }
}
