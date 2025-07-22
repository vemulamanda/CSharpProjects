namespace CollectionsProject
{
    // These are lambda expressions which are simplified method of calling delegates
    // introduced in c# 6.0

    internal class DelegateAnonymousMethodsUpgradedNew
    {
        static void Main()
        {
            SayHelloDelegate SHD = name => $"Hello {name}. Good Morning.";

            Console.WriteLine(SHD("Sudheer"));
        }        
    }
}
