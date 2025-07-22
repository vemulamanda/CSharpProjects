namespace CollectionsProject
{
    internal partial class PartialClass : GenericExampleOne
    {
        public void Method1()
        {
            Console.WriteLine("Thiis is method-1 and class-1");
        }
        public void Method2()
        {
            Console.WriteLine("This is method-2 and class-1");
        }
        static void Main()
        {
            PartialClass PC = new PartialClass();
            PC.Method1();PC.Method2();
            PC.Method3();PC.Method4();
        }
    }
}
