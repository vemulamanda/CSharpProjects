namespace CollectionsProject
{
    //If you want to execute 2 methods parallely in same thread we can do it using "continue with".
    internal class TaskMethodChaining
    {
        public static void M1(int a, int b)
        {
            Console.WriteLine($"The addition of a and b are: {a + b}");
        }
        public static void M2(int a, int b)
        {
            Console.WriteLine($"The subtraction of a and b are: {a - b}");
        }
        public static void M3(int a, int b)
        {
            Console.WriteLine($"The Multiplication of a and b are: {a * b}");
        }
        public static void M4(int a, int b)
        {
            Console.WriteLine($"The Division of a and b are: {a / b}");
        }

        static void Main()
        {
            Task T1 = Task.Factory.StartNew(() => M1(5, 5)).ContinueWith((first) => Console.WriteLine()).ContinueWith((second) => M2(5,5));
            Task T2 = Task.Factory.StartNew(() => M3(5, 5)).ContinueWith((first) => Console.WriteLine()).ContinueWith((second) => M4(5, 5));

            T1.Wait(); T2.Wait();
        }
    }
}
