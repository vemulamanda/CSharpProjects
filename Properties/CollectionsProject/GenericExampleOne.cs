//This is one method of passing the type using generics. This gives type safe..

namespace CollectionsProject
{
    internal class GenericExampleOne
    {
        public bool Compare <T> (T a, T b)
        {
            if(a.Equals(b))
                return true;
            return false;
        }
        static void Main()
        {
            GenericExampleOne GEO = new GenericExampleOne();
            Console.WriteLine (GEO.Compare<int>(2, 2));
            Console.WriteLine (GEO.Compare<bool>(true, false));
            Console.WriteLine (GEO.Compare<string>("sudheer", "eswar"));
            Console.WriteLine (GEO.Compare<char>('a', 'b'));
        }
    }
}
