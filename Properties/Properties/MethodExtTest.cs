namespace Properties
{
    static class MethodExtTest
    {
        public static void Test3(this MethodExt ME, int i)
        {
            Console.WriteLine("From Extention Method: " + i);
        }
    }
}
