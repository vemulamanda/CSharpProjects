namespace CollectionsProject
{
    internal class ArrayGenericsClass1
    {
        static void Main()
        {
            List <int> list1 = new List<int>() { 60, 37, 74, 68, 11, 21, 77, 90, 2, 3, 65};
            List<int> list2 = new List<int>();

            foreach (var num in list1)
            {
                if(num > 50)
                    list2.Add(num);
            }

            list2.Sort();
            list2.Reverse();

            Console.WriteLine(string.Join(", ", list2));
        }
    }
}
