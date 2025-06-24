//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace MultiThreadDemo
//{
//    internal class Program5
//    {
//        static long total_size = 0;
//        static object objlock = new object();
//        static long pending = 0;
//        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
//        static void processFolder(string path)
//        {
//            try
//            {
//                foreach (string filepath in Directory.GetFiles(path))
//                {
//                    try
//                    {
//                        long size = new FileInfo(filepath).Length;
//                        lock (objlock)
//                        {
//                            total_size += size;
//                        }
//                    }
//                    catch { }
                   
//                }
//                foreach (string folder in Directory.GetDirectories(path))
//                {
//                    Interlocked.Increment(ref pending);
//                    Task.Run(() =>
//                    {
//                        processFolder(folder);
//                    });
//                }
//            }
//            catch (Exception ex)
//            {

//            }
//            if(Interlocked.Decrement(ref pending) == 0)
//            {
//                autoResetEvent.Set();
//            }

//        }
//        static void Main(string[] args)
//        {
//            var stopwatch = Stopwatch.StartNew();
//            string path = "E:\\E盘备份";
//            Interlocked.Increment(ref pending);
//            Task.Run(() =>
//            {
//                processFolder(path);
//            });
            
//            autoResetEvent.WaitOne();
//            stopwatch.Stop();
//            Console.WriteLine(total_size);
//            Console.WriteLine($"耗时：{stopwatch.Elapsed.TotalSeconds:F2} 秒");
//        }
//    }
//}
