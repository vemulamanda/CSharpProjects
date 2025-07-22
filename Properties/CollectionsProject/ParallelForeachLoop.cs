using System.Diagnostics;

namespace CollectionsProject
{
    internal class ParallelForeachLoop
    {
        static void Main()
        {
            Stopwatch sw1 = new Stopwatch();

            sw1.Start();
            //This is sequential for-loop, i.e legacy for loop.
            string str1 = "";
            for(int i = 0; i < 100000; i++)
                str1 += i;

            sw1.Stop();

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            //This is parallel for-loop.
            string str2 = "";
            Parallel.For(1, 100000, i => 
                str2 += i 
            );

            sw2.Stop();

            Console.WriteLine($"The time taken to complete sequential loop is: {sw1.ElapsedMilliseconds}");
            Console.WriteLine($"The time taken to complete parallel loop is: {sw2.ElapsedMilliseconds}");

            //sequntial for each loop
            int[] arr = { 11, 22, 33, 44, 55, 66, 77, 88, 99, 111, 121 };

            foreach (var item in arr)
            {
                Console.WriteLine($"The thread ID is: {Thread.CurrentThread.ManagedThreadId},, The item is {item}");
            }

            //Parallel for each loop
            Parallel.ForEach(arr, item =>
            {
                Console.WriteLine($"The thread ID is: {Thread.CurrentThread.ManagedThreadId},, The item is {item}");
            });
        }
    }
}
