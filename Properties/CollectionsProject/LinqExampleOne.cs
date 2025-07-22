using System.Threading.Tasks.Dataflow;

namespace CollectionsProject
{
    internal class LinqExampleOne
    {
        static void Main()
        {
            List<int> list1 = new List<int>() { 60, 37, 74, 68, 11, 21, 77, 90, 2, 3, 65 };
            var list2 = from i in list1 where i > 40 orderby i descending select i;
            Console.WriteLine(string.Join(", ", list2));

            int[] Arr = { 60, 37, 74, 68, 11, 21, 77, 90, 2, 3, 65 };
            var Brr = from i in Arr where i > 40 orderby i descending select i;
            Console.WriteLine(string.Join(", ", Brr));

            //=========================================================================

            List<string> colors = new List<string>() { "Yellow", "Magenta", "Red", "Green", "Black", "Brown", "pink" };

            var colors1 = from s in colors where s.Length == 3 select s;
            Console.WriteLine(string.Join(" ", colors1));

            var colors2 = from s in colors where s.StartsWith('B') select s;
            Console.WriteLine(string.Join(" ", colors2));

            var colors3 = from s in colors where s[0] == 'B' select s;
            Console.WriteLine(string.Join(" ", colors3));

            var colors4 = from s in colors where s.IndexOf('B') == 0 select s;
            Console.WriteLine(string.Join(" ", colors4));

            var colors5 = from s in colors where s.Substring(0, 1) == "B" select s;
            Console.WriteLine(string.Join(" ", colors5));

            var colors6 = from s in colors where s.EndsWith('k') select s;
            Console.WriteLine(string.Join(" ", colors6));

            var colors7 = from s in colors where s[s.Length - 1] == 'k' select s;
            Console.WriteLine(string.Join(" ", colors7));

            var colors8 = from s in colors where s.IndexOf("k") == s.Length - 1 select s;
            Console.WriteLine(string.Join(" ", colors8));

            var colors9 = from s in colors where s.Substring(s.Length - 1) == "k" select s;
            Console.WriteLine(string.Join(" ", colors9));

            var colors10 = from s in colors where s[2] == 'e' select s;
            Console.WriteLine(string.Join(" ", colors10));

            var colors11 = from s in colors where s.IndexOf('e') == 2 select s;
            Console.WriteLine(string.Join(" ", colors11));

            var colors12 = from s in colors where s.Substring(2, 1) == "e" select s;
            Console.WriteLine(string.Join(" ", colors12));

            var colors13 = from s in colors where s.Contains("o") select s;
            Console.WriteLine(string.Join(" ", colors13));

            var colors14 = from s in colors where s.ToUpper().Contains("O") select s;
            Console.WriteLine(string.Join(" ", colors14));
        }
    }
}
