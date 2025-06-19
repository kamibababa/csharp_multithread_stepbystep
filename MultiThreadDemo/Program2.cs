//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MultiThreadDemo
//{
//    internal class Program2
//    {
//        static int CalculatePrimes(int max)
//        {
//            int count = 0;

//            for (int i = 2; i <= max; i++)
//            {
//                if (IsPrime(i))
//                {
//                    count++;
//                }
//            }

//            return count;
//        }

//        static bool IsPrime(int number)
//        {
//            if (number <= 1) return false;

//            for (int i = 2; i * i <= number; i++)
//            {
//                if (number % i == 0)
//                    return false;
//            }

//            return true;
//        }

//        static void Main(string[] args)
//        {
//            int thread_count = 10;
//            CountdownEvent countdown = new CountdownEvent(thread_count);
//            Stopwatch sw = new Stopwatch();
//            sw.Start();
//            int times = 10000000;
//            int count = 0;

//            //Thread thread = new Thread(() =>
//            //{
//            //count = CalculatePrimes(times);
//            //Console.WriteLine(count);
//            //countdown.Signal();
//            //});

//            //thread.Start();

//            //Task<int> task =Task.Run(() =>
//            //{
//            //    count = CalculatePrimes(times);
//            //    //countdown.Signal();
//            //    return count;
//            //});

//            //int result = task.Result;
//            //Console.WriteLine(result);

//            //task.Start();
//            //count = task.Result;
//            //Console.WriteLine(count);
//            Task<int>[] tasks = new Task<int>[thread_count];
//            for (int i = 0; i < thread_count; i++)
//            {
//                tasks[i] = Task.Run(() =>
//                {
//                    count = CalculatePrimes(times);
//                    countdown.Signal();
//                    return count;
//                });
//            }
//            //ThreadPool.QueueUserWorkItem(state =>
//            //{
//            //    count = CalculatePrimes((int)state);
//            //    Console.WriteLine(count);
//            //    countdown.Signal();
//            //},times);
//            //Thread thread = new Thread(() =>
//            //{
//            //    count = CalculatePrimes(times);
//            //    Console.WriteLine(count);
//            //    countdown.Signal();
//            //});

//            //thread.Start();
//            //}

//            Task<int[]> results = Task.WhenAll(tasks);
//            foreach (int result in results.Result)
//            {
//                Console.WriteLine(result);
//            }
//            //countdown.Wait();
//            //Console.WriteLine(count);
//            sw.Stop();
//            Console.WriteLine(sw.ElapsedMilliseconds);
//        }
//    }
//}
