namespace CollectionsProject
{
    internal class MultiThreading
    {      
        static void test1()
        {
            Console.WriteLine("Thread 1 is starting.");
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("Method-01");               
            }
            Console.WriteLine("Thread 1 is exiting.");
        }
        static void test2()
        {
            Console.WriteLine("Thread 2 is starting.");
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("Method-02");               
            }
            Console.WriteLine("Thread 2 is exiting.");
        }
        static void Main()
        {
            //MultiThreading MT = new MultiThreading();
            //MT.test1(); MT.test2();
            Thread T1 = new Thread(test1);
            Thread T2 = new Thread(test2);
            T1.Start(); T2.Start();
            T1.Join(9000); T2.Join();
        }
    }

    //Example -2: Thread Locking

    class ThreadLocking
    {
        public void Method1()
        {
            lock (this)
            { 
                //If static method is used,, below is lock syntax..
                //This lock should be implemented for thread or task to function synchronously..

                //public static void Method1()
                //{
                //    lock (typeof(ThreadLocking)) 
                //{
                Console.Write("[CSharp is a ");
                Thread.Sleep(5000);
                Console.WriteLine("Object Oriented language]");
            }
        }
            static void Main()
            {
                ThreadLocking TL = new ThreadLocking();
                Thread T3 = new Thread(TL.Method1);
                Thread T4 = new Thread(TL.Method1);
                T3.Start(); T4.Start();
            }
    }

    //Example -3:  Thread Priority

    class ThreadPriorityTest
    {
        static long count1, count2;
        public static void M1()
        {
            while (true)
            {
                 count1 += 1;
            }
        }
        public static void M2()
        {
            while (true)
            {
                count2 += 1;
            }
        }
        static void Main()
        {
            //ThreadPriorityTest TP = new ThreadPriorityTest();
            Thread T1 = new Thread(M1);
            Thread T2 = new Thread(M2);

            T1.Priority = ThreadPriority.Highest;
            T2.Priority = ThreadPriority.Lowest;

            T1.Start();
            T2.Start();

            Console.WriteLine("Main thead going to sleep.");
            Thread.Sleep(10000);
            Console.WriteLine("Main thread exiting");

            //T1.Abort();
            //T2.Abort();

            T1.Join();
            T2.Join();

            Console.WriteLine("Count1: " + count1);
            Console.WriteLine("Count2: " + count2);
        }
    }

    class TaskParallelism
    {
        static void test1()
        {
            Console.WriteLine("Thread 1 is starting.");
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("Method-01");

                if (i == 25)
                {
                    Console.WriteLine("Thread 1 is sleeping for 10 sec now.");
                    //Thread.Sleep(10000);
                    //     OR
                    Task.Delay(10000).Wait();
                }
            }
            
            Console.WriteLine("Thread 1 is exiting.");
        }
        static void test2()
        {
            Console.WriteLine("Thread 2 is starting.");
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("Method-02");
            }
            Console.WriteLine("Thread 2 is exiting.");
        }
        static void Main()
        {
            //Task T1 = new Task(test1);
            //Task T2 = new Task(test2);

            //T1.Start(); T2.Start();

            //T1.Wait(); T2.Wait();

            //      OR

            Task T1 = Task.Factory.StartNew(test1);
            Task T2 = Task.Factory.StartNew(test2);
            
            //T1.Wait();T2.Wait();
            //      OR
            Task.WaitAll(T1, T2);
        }
    }

    class TPValueReturning
    {
        static int test1()
        {
            string str = "";
            for (int i = 0; i < 500; i++)
            {
                str += i;
            }
            return str.Length;
        }
        static string test2()
        {
            string str = "Hello World";
            return str.ToUpper();
        }
        static void Main()
        {
            Task<int> T1 = new Task<int>(test1);
            Task<string> T2 = new Task<string>(test2);

            T1.Start(); T2.Start();

            int result1 = T1.Result;
            string result2 = T2.Result;

            Console.WriteLine(result1);
            Console.WriteLine(result2);


            Console.WriteLine("Exiting the main method.");
        }
    }

    class ParameterizedTPL
    {
        static int test1(int ub)
        {
            string str = "";
            for (int i = 0; i < ub; i++)
            {
                str += i;
            }
            return str.Length;
        }
        static string test2(string str)
        {
            return str.ToUpper();
        }
        static void Main()
        {
            //Task<int> T1 = new Task<int>(() => test1(1000));
            //Task<string> T2 = new Task<string>(() => test2("Hello World"));

            //T1.Start(); T2.Start();

                        //OR

            Task<int> T1 = Task.Factory.StartNew(() => test1(1000));
            Task<string> T2 = Task.Factory.StartNew(() => test2("Hello World")); //This method is used to eliminate start method.

            int result1 = T1.Result;
            string result2 = T2.Result;

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            
            Console.WriteLine("Exitng main method");

        }
    }
}

