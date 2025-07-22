using System.Collections;

namespace CollectionsProject
{
    internal class ArrayListExample
    {
        static void Main()
        {
            ArrayList AL1 = new ArrayList(1);
            //Here "1" represents the size of the array to begin with.
            AL1.Add(1); AL1.Add(null);  AL1.Add("sudheer kumar"); AL1.Add(2.014);
            AL1.Add(null); AL1.Add(true); AL1.Add("Eswar kumar"); AL1.Add(31.54);
            AL1.Add(null);
            
            for (int i = 0; i < AL1.Count; i++)
            {
                //Console.WriteLine("The elements of array list are: " + AL[i]);
            }

            Console.WriteLine();
            //AL.Remove(null);
            //AL.RemoveAt(4);
            //AL.RemoveRange(1,2);
            //AL.Insert(1,false);
            Console.WriteLine("The capacity of array is: " + AL1.Capacity);
            foreach (var element in AL1)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();

            ArrayList AL2 = new ArrayList(AL1);
            //When we copy, the capacity starts from the count of number of elements in the copied list(Here AL1).
            Console.WriteLine("Capacity after copying another array list :" + AL2.Capacity);

            //So, if AL1 contains 5 elements the capacity starts from 5 and when we add 6th element, capacity doubles which becomes 10.
            AL2.Add("Sudheer"); AL2.Add("Eswar"); AL2.Add(true);
            Console.WriteLine("Capacity after adding 3 more elements into array list :" + AL2.Capacity);

            //This TrimToSize method trims the capacity to the size of number of elements in the array,,
            //which will be helpful save the memory space.
            AL2.TrimToSize();
            Console.WriteLine("Capacity after calling trim to size method :" + AL2.Capacity);
        }
    }
}
