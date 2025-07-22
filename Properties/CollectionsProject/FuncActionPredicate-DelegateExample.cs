namespace CollectionsProject
{
    //public delegate int delegate01(int x, int y);
    //public delegate void delegate02(int x, int y);
    //public delegate bool delegate03(string str);

    internal class FuncActionPredicate_DelegateExample
    {
        public static int AddNums1(int a, int b)
        {
             return a + b;
        }
        public static void SubNums2(int a, int b)
        {
            Console.WriteLine(a - b);
        }
        public static bool CheckLength(string str)
        {
            if (str.Length < 5)
                return false;
            return true;
        }
        static void Main()
        {
            /*  delegate01 d1 = new delegate01(AddNums1);
              int add = d1.Invoke(10,15);
              Console.WriteLine(add);

              delegate02 d2 = new delegate02(SubNums2);
              d2.Invoke(10,15);

              delegate03 d3 = new delegate03(CheckLength);
              bool CL = d3.Invoke("sudheer");
              Console.WriteLine(CL);
            */

            //Note: Only keep using Func, Action or predicate delegate from next time if you want to define a delegate.


            //Func delegate is allowed to pass 16 input parameetrs and 1 output parameter.
            //This is used for value returning methods.
            Func<int, int, int> d1 = AddNums1;
            int add = d1.Invoke(10, 15);
            Console.WriteLine(add);

            //Action delegate takes 16 in put parameters, it is used for non returning values methods
            Action<int, int> d2 = SubNums2;
            d2.Invoke(10, 15);

            //Predicate delegate takes single parameter and returns bool value.
            //This is only used to return bool value
            Predicate<string> d3 = CheckLength;
            bool CL = d3.Invoke("sudheer");
            Console.WriteLine(CL);
        }
    }
}
