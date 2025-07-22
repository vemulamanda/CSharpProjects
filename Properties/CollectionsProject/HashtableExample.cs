using System.Collections;
namespace CollectionsProject
{
    internal class HashtableExample
    {
        static void Main()
        {
            Hashtable HT = new Hashtable();
            HT.Add("ID", 101); HT.Add("Name", "Sudheer");
            HT.Add("Salary", 50000); HT.Add("Mgr-ID", null);
            HT.Add("Designation", "Devops Engineer");

            foreach (var obj in HT.Keys)
            {
                Console.WriteLine(obj + " : " + HT[obj]);
            }
        }
        
    }
}
