namespace CollectionsProject
{
    internal class DelegateAnonymousMethodsUpgraded
    {
        static void Main()
        {
            SayHelloDelegate SHD = (str) =>
            {
                return $"Hello {str}. Good Morning.";
            };
            
            Console.WriteLine(SHD("Mahesh"));
            Console.WriteLine(SHD("Nani"));

            AddDelegate AD = (a, b) =>
            {
                Console.WriteLine($"The Addition of 2 numbers are: {a + b}");
            };

            AD(2, 5);
        }
    }
}
