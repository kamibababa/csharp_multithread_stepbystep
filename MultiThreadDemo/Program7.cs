using System;
using System.Diagnostics;

namespace MultiThreadDemo
{
    internal class Program
    {
        static int total = 0;
        private static readonly object sizeLock = new object();
        static void printChar()
        {
            Thread.Sleep(3000);
            //for(int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine((char)('a'+i));
            //    Thread.Sleep(1);
            //}
        }
        static void printChar(int n)
        {
            Thread.Sleep(5000);
            //Console.WriteLine("printChar2:" + Thread.CurrentThread.ManagedThreadId);
            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine((char)('a' + i));
            //    Thread.Sleep(1);
            //}
        }
        //664579
        //1270607
        //3001134
        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int taskCount = 10;
            CountdownEvent countdown = new CountdownEvent(taskCount);
            int range = 10000000 / taskCount;

            for (int i = 0; i < 10000000; i += range)
            //for (int i = 0; i < taskCount; i++)
            {
                Thread thread = new Thread((x) =>
                {

                    int num = CalculatePrimes((int)x, (int)x + range);
                    Thread.Sleep(1000);
                    //lock (sizeLock)
                    {
                        total += num;
                    }
                    //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    countdown.Signal();
                });
                thread.Start(i);
            }

            countdown.Wait();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine(total);


            //int processorCount = Environment.ProcessorCount;  // 获取逻辑处理器核心数
            //int recommendedThreads = processorCount + 1;

            //Console.WriteLine($"逻辑核心数: {processorCount}");
            //Console.WriteLine($"CPU密集型任务推荐线程数: {recommendedThreads}");
            //Stopwatch sw = new Stopwatch();
            //sw.Start();

            //int count = CalculatePrimes(1, 50000000); // 根据机器性能，可调整数字让它耗时几秒

            //sw.Stop();

            //Console.WriteLine($"共找到素数 {count} 个");
            //Console.WriteLine($"耗时: {sw.Elapsed.TotalSeconds:F2} 秒");
        }

        static int CalculatePrimes(int start, int end)
        {
            //Console.WriteLine(end);
            int count = 0;

            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    count++;
                }
            }

            return count;
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
        //static void Main(string[] args)
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    int num = 5;
        //    Thread thread = new Thread(() =>
        //    {
        //        printChar(num);
        //    });
        //    Thread thread2 = new Thread(() =>
        //    {
        //        printChar();
        //    });

        //    thread.Start();
        //    thread2.Start();

        //    thread.Join();
        //    thread2.Join();

        //    stopwatch.Stop();

        //    Console.WriteLine(stopwatch.ElapsedMilliseconds);
        //    //int num = 5;
        //    //Thread thread = new Thread(() =>
        //    //{
        //    //    printChar2(num);
        //    //});
        //    //Console.WriteLine("Main:" + Thread.CurrentThread.ManagedThreadId);
        //    //thread.Start();
        //    //Console.WriteLine("Hello, World!");
        //    //for (int i = 0; i < 10; i++)
        //    //{
        //    //    Console.WriteLine(i);
        //    //    Thread.Sleep(1);
        //    //}
        //}
    }
}
