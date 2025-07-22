namespace CollectionsProject
{
    internal class GenericsExampleTwo
    {
        //In this scenario you can pass two different types. 
       public bool AreEqual <T1, T2> (T1 a, T2 b)
        {
            if(a.Equals(b))
                return true;
            return false;
        }
        static void Main()
        {
            GenericsExampleTwo GET = new GenericsExampleTwo();
            Console.WriteLine(GET.AreEqual<int, int> (2, 2));
            Console.WriteLine(GET.AreEqual<bool, bool> (true, false));
            Console.WriteLine(GET.AreEqual<string, string> ("sudheer", "eswar"));
            Console.WriteLine(GET.AreEqual<double, double> (25.24, 25.24));
        }
    }
}
