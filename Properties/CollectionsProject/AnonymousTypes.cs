namespace CollectionsProject
{
    internal class AnonymousTypes
    {
        static void Main()
        {
            var Emp = new { id = 100, Name = "Sudheer", Designation = "Devops Engineer", Salary = 65000.50, Dept = new { D_id = 500, D_Name = "Infra_Department", D_Location = "India" } };
            Console.WriteLine(Emp.GetType() + "\n");

            Printer.Print(Emp);            
        }
    }

    internal class Printer
    {
        public static void Print(dynamic E)
        {
            Console.WriteLine("Employee ID: " + E.id);
            Console.WriteLine("Employee Name: " + E.Name);
            Console.WriteLine("Employee Designation: " + E.Designation);
            Console.WriteLine("Employee Salary: " + E.Salary);
            Console.WriteLine("Department ID : " + E.Dept.D_id);
            Console.WriteLine("Department Name : " + E.Dept.D_Name);
            Console.WriteLine("Department Location : " + E.Dept.D_Location);
        }
    }
}
