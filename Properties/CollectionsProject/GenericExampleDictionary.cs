namespace CollectionsProject
{
    internal class GenericExampleDictionary
    {
        static void Main()
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("ID", 101); Dic.Add("Name", "Sudheer");
            Dic.Add("Salary", 50000); Dic.Add("Mgr-ID", null);
            Dic.Add("Designation", "Devops Engineer");

            foreach (var item in Dic.Keys)
            {
                Console.WriteLine(item +  ": " + Dic[item]);
            }
        }
    }
}
