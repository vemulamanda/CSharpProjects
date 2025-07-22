using System.Collections;

namespace CollectionsProject
{
    public class Employee
    {
        public int Sid { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public double Salary { get; set; }
    }

    public class Organization : IEnumerable
    {
        List<Employee> emps = new List<Employee>();
        public void ADD(Employee emp)
        {
            emps.Add(emp);
        }

        public int count
        {
            get { return emps.Count; }
        }

        public Employee this[int index]
        {
            get { return emps[index]; }
        }

        public IEnumerator GetEnumerator()
        {
            return emps.GetEnumerator();
        }

    }

    public class OrganizationEnumerator : IEnumerator
    {
        Organization OrgColl;
        int CurrentIndex;
        Employee CurrentEmployee;

        public OrganizationEnumerator(Organization org)
        {
            OrgColl = org;
            CurrentIndex = -1;
        }
        public object Current =>  CurrentEmployee;

        public bool MoveNext()
        {
            if (++CurrentIndex >= OrgColl.count)
                return false;
            else
                CurrentEmployee = OrgColl[CurrentIndex];
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    public class TestEmployee
    {

        static void Main()
        {
            Organization Employees = new Organization();
            Employees.ADD(new Employee { Sid = 108, Name = "sudheer", Salary = 60000, Class = 5 });
            Employees.ADD(new Employee { Sid = 101, Name = "eswar", Salary = 61624, Class = 5 });
            Employees.ADD(new Employee { Sid = 108, Name = "srija", Salary = 60833, Class = 5 });
            Employees.ADD(new Employee { Sid = 107, Name = "siri", Salary = 61000, Class = 5 });
            Employees.ADD(new Employee { Sid = 105, Name = "varma", Salary = 70000, Class = 5 });

            foreach (var emp in Employees)
            {
            //    Console.WriteLine($"Emp-ID: {emp.Sid} Name: {emp.Name} Salary: {emp.Salary} Class: {emp.Class}");
            }
        }
    }
}
