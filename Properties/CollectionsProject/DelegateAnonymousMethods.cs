namespace CollectionsProject
{
    //These anonymous methods can be used only to reduce the code we write, i.e, to avoid duplication.
    //We can use this when we can access the method only within this class(like private method) and method contains 2-3 lines of code.
    //In this Anaonymous methods, it eliminates modifiers, types. 
    internal class DelegateAnonymousMethods
    {
        /*public string GoodMorning(string str)
        {
            return $"Hello {str}. Good Morning.";
        }*/
        static void Main()
        {
            //DelegateAnonymousMethods DAM  = new DelegateAnonymousMethods();

            SayHelloDelegate SHD = delegate (string str)
            {
                return $"Hello {str}. Good Morning.";
            };

            Console.WriteLine(SHD("Sudheer"));
            Console.WriteLine(SHD("Eswar"));
        }
    }
}

