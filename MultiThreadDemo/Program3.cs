//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MultiThreadDemo
//{
//    internal class Program3
//    {
//        static int ticket_count = 100;
//        static object lockobj = new object();
//        static void Main()
//        {
//            Task[] tasks = new Task[4];
//            for (int i = 0; i < 4; i++)
//            {
//                int window = i + 1;
//                tasks[i] = Task.Run(() => sellTicket(window));
//            }

//            Task.WaitAll(tasks);
//            Console.WriteLine("over");
//        }

//        static public void sellTicket(int window)
//        {
//            while (true)
//            {
//                //lock (lockobj)
//                int newCount = Interlocked.Decrement(ref ticket_count);
//                {
//                    if (newCount >= 0)
//                    {
//                        Thread.Sleep(1);
//                        Console.WriteLine($"window{window} sell {100 - newCount} left{newCount}");
//                        //ticket_count--;
//                    }
//                    else
//                    {
//                        Console.WriteLine($"窗口{window}：票已售完");
//                        break;
//                    }
//                }

//            }

//        }
//    }
//}
