using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.Arm;

namespace CollectionsProject
{
    internal class LinqExampleTwoTest
    {
        static void Main()
        {
            LinqCustomer C1 = new LinqCustomer { ID = 101, Name = "Sudheer", Role = "Devops Engineer", salary = 17000.32, Status = true};
            LinqCustomer C2 = new LinqCustomer { ID = 102, Name = "Eswar", Role = "Devops Engineer", salary = 10000.32, Status = true };
            LinqCustomer C3 = new LinqCustomer { ID = 103, Name = "Srija", Role = "Devops Engineer", salary = 13000.32, Status = false };
            LinqCustomer C4 = new LinqCustomer { ID = 104, Name = "Siri", Role = "Assurance Manager", salary = 14000.32, Status = true };
            LinqCustomer C5 = new LinqCustomer { ID = 105, Name = "Avi", Role = "Developer", salary = 17000.32, Status = false };


            List<LinqCustomer> list1 = new List<LinqCustomer>() { C1, C2, C3, C4, C5 };
            //select Clause
            //var list2 = from c in list1 select c;
            //var list2 = from c in list1 select new {c.ID, c.Name, c.Role}; 
             
            //orderby clause
            //var list2 = from c in list1 orderby c.salary select new {c.ID, c.Name, c.salary};

            //where clause
            //var list2 = from c in list1 where c.salary < 12000 select new { c.ID, c.Name, c.salary };
            //var list2 = from c in list1 where c.Status == true && c.salary > 13000 select c;

            //GroupBy clause
            /*Here you first get the list and then divide the list into groups using group by. This means that
            if the list contains 2 devops engineer roles it is considered as one group. After that all the groups
            are collected under "g". Then we apply aggregate functions like count, min, max on that.
            
             1. When working with group by the first thing we need to know is what is the key cloumn we want to work on.
             2. The column used in key should not be unique in the list like ID or Name, it should have duplicates.*/

            //var list2 = from c in list1 group c by c.Role into g select new { Role = g.Key, NoOfEmployees = g.Count() };
            //var list2 = from c in list1 group c by c.Role into g select new { Role = g.Key, NoOfEmployees = g.Count(), CalSalary = g.Max(c => c.salary) };
            //var list2 = from c in list1 group c by c.Role into g select new { Role = g.Key, NoOfEmployees = g.Count(), Cal_Salary = g.Min(c => c.salary) };
            //var list2 = from c in list1 group c by c.Role into g select new { Salary = g.Key, NoOfEmployees = g.Count(), Cal_Salary = g.Average(c => c.salary) };
            //var list2 = from c in list1 group c by c.Status into g select new { Status = g.Key, NoOfEmps = g.Count(), Cal_Salary = g.Sum(c => c.salary) };

            //Having Clause
            /* You dont have having clause in LINQ queries, this is only used in sql queries,
             But in LINQ queries instead of Having clause we use where clause. Here if we use where clause
            before group by clause we are performing filtering on list and if we use where clause after group by 
            we are performing filter on group "g"(see below query).*/

            //var list2 = from c in list1 group c by c.Status into g where g.Key == true select new { Name = g.Key, Cal_Salary = g.Sum(c => c.salary) };
            //var list2 = from c in list1 group c by c.Role into g where g.Min(c => c.salary) < 12000 select new { Role = g.Key, Cal_Salary = g.Max(c => c.salary) };
            //var list2 = from c in list1 group c by c.salary into g where g.Max(c => c.salary) < 12000 select new { salary = g.Key, cal_salary = g.Max(c => c.salary) };
            var list2 = from c in list1 where c.salary > 12000 group c by c.Status into g where g.Key == true select new { status = g.Key, Cal_Salary = g.Sum(c => c.salary) };

            foreach (var cust in list2)
            {
                Console.WriteLine(cust);
            }

        }
    }
}
