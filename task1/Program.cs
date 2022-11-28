using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива");
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> funk1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(funk1, n);

            //Func<Task<int[]>, int> funk2 = new Func<Task<int[]>, int>(GetArray);
            //Task<int[]> task2 = task1.ContinueWith<int[]>(funk2);

            Action<Task<int[]>> action = new Action<Task<int[]>>(PrintArray);
            Task task3 = task1.ContinueWith(action);

            task1.Start();
            Console.ReadKey();
        }

        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            int Sum = 0;
            int max = array[0];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
                Sum += array[i];
                foreach (int a1 in array)
                {
                    if (a1 > max)
                        max = a1;
                }
                Console.Write("{0} ", array[i]);
                Console.WriteLine(Sum);
                Console.WriteLine(max);
            }
            return array;
        }

        //static int Max(int[] array)
        //{
        //    int[] array = new int[n];

        //    int max = array[0];
        //    foreach (int a in array)
        //    {
        //        if (a > max)
        //            max = a;
        //    }
        //    Console.WriteLine(max);
        //    Console.ReadKey();
        //}

        static void PrintArray(Task<int[]> task)
        {
            int[] array = task.Result;
            for (int i = 0; i < array.Count(); i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}
