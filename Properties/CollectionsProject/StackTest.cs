using System.Collections;
namespace CollectionsProject
{
    internal class StackTest
    {
        static void Main()
        {
            Stack S = new Stack();
            S.Push("Sudheer"); S.Push(1);
            S.Push(true); S.Push(null); S.Push(10.254);

            foreach (var values in S)
            {
                Console.WriteLine("The values are: " + values);
            }

            Console.WriteLine();

            S.Pop();

            foreach (var values in S)
            {
                Console.WriteLine("The values are: " + values);
            }

            S.Peek();

            Console.WriteLine();

            foreach (var values in S)
            {
                Console.WriteLine("The values are: " + values);
            }

            Queue Q = new Queue();
            Q.Enqueue("eswar"); Q.Enqueue(1);
            Q.Enqueue(null); Q.Enqueue(20.45);

            Console.WriteLine();

            foreach (var value in Q)
            {
                Console.WriteLine("The values are: " + value);
            }

            Console.WriteLine();
        }
    }
}
