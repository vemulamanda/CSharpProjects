namespace CollectionsProject
{
    //Unicast Delegate Example: Unicast is only one menthod can be passed to one delegate.
    internal class DelegatesExampleOne
    {
        public void Add(int a, int b)
        {
            Console.WriteLine($"The addition of 2 numbers are: {a + b}");
        }
        public static string SayHello(string name)
        {
            return $"Hi {name}. How are you doing?";
        }
        static void Main()
        {
            SayHelloDelegate SHD = new SayHelloDelegate(SayHello);
            Console.WriteLine(SHD("sudheer"));
            Console.WriteLine(SHD("eswar"));

            Console.WriteLine();

            DelegatesExampleOne DEO = new DelegatesExampleOne();
            AddDelegate AD = new AddDelegate(DEO.Add);
            AD(2,4); AD(5, 8); AD(54, 876);
        }
    }
}
