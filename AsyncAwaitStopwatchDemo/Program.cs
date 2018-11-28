using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwaitStopwatchDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Tasks tasks = new Tasks();

            //First, call the tasks normally, and run a stopwatch.
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var task1 = tasks.OneSecondTask();
            var task2 = tasks.TwoSecondTask();
            var task3 = tasks.ThreeSecondTask();
            var task4 = tasks.FourSecondTask();
            
            Task.WaitAll(task1, task2, task3, task4);

            watch.Stop();

            Console.WriteLine("Standard call, watch runs for " + watch.ElapsedMilliseconds + " milliseconds");
            Console.WriteLine("Press Enter to run watches on each task.");

            Console.ReadLine();

            Console.WriteLine(Environment.NewLine);

            //Now, add a stopwatch call to each of them.

            var task1watch = new Stopwatch();
            task1watch.Start();
            var watchtask1 = tasks.OneSecondTask().ContinueWith(x =>
            {
                task1watch.Stop();
                Console.WriteLine("Task 1 took " + task1watch.ElapsedMilliseconds + " milliseconds to run.");
            });

            var task2watch = new Stopwatch();
            task2watch.Start();
            var watchtask2 = tasks.TwoSecondTask().ContinueWith(x =>
            {
                task2watch.Stop();
                Console.WriteLine("Task 2 took " + task2watch.ElapsedMilliseconds + " milliseconds to run.");
            });

            var task3watch = new Stopwatch();
            task3watch.Start();
            var watchtask3 = tasks.ThreeSecondTask().ContinueWith(x =>
            {
                task3watch.Stop();
                Console.WriteLine("Task 3 took " + task3watch.ElapsedMilliseconds + " milliseconds to run.");
            });

            var task4watch = new Stopwatch();
            task4watch.Start();
            var watchtask4 = tasks.FourSecondTask().ContinueWith(x =>
            {
                task4watch.Stop();
                Console.WriteLine("Task 4 took " + task4watch.ElapsedMilliseconds + " milliseconds to run.");
            });

            Task.WaitAll(watchtask1, watchtask2, watchtask3, watchtask4);

            Console.ReadLine();
        }
    }
}
