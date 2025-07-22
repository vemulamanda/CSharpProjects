namespace CollectionsProject
{
    internal class GenericExampleThree<T>
    {
        public T x;
        public T ADD (T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            return d1 + d2;
        }
        public T SUB (T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            return d1 - d2;
        }
        public T MUL (T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            return d1 * d2;
        }
        public T DIV (T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            return d1 / d2;
        }
        
    }

    internal class Math
    {
        static void Main()
        {
            GenericExampleThree<int> GI = new GenericExampleThree<int>();
            GenericExampleThree<double> GD = new GenericExampleThree<double>();
            Console.WriteLine(GI.x);
            Console.WriteLine(GD.x);
            Console.WriteLine(GI.ADD(1, 2));
            Console.WriteLine(GI.SUB(2, 3));
            Console.WriteLine(GD.ADD(3.4, 6.4));
            Console.WriteLine(GD.SUB(20.4, 65.32));
        }
    }
}
