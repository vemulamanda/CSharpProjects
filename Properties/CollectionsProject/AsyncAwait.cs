namespace CollectionsProject
{
    internal class AsyncAwait
    {
        public async void M1()
        {
            Console.WriteLine("Hi");
            await Task.Delay(5000);
            Console.WriteLine("Prend");
        }
        public void M2()
        {
            Console.Write("Hi ");
            Console.WriteLine("sudheer");
        }
        static void Main()
        {
            AsyncAwait AA = new AsyncAwait();
            AA.M1(); AA.M2();

            Console.ReadLine();
        }
    }
}
