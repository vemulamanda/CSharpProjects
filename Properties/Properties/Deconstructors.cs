namespace Properties
{
    internal class Deconstructors
    {
        int Id;
        string? Name, Designation;
        double Salary;
        bool Status;

        public Deconstructors(int Id, string Name, string Designation, double Salary, bool Status)
        {
            this.Id = Id;
            this.Name = Name;
            this.Designation = Designation;
            this.Salary = Salary;
            this.Status = Status;
        }

        public void Deconstruct(out int Id, out string? Name, out string? Designation, out double Salary, out bool Status)
        {
            Id = this.Id;
            Name = this.Name;
            Designation = this.Designation;
            Salary = this.Salary;
            Status = this.Status;
        }

        static void Main()
        {
            Deconstructors obj1 = new Deconstructors(101, "Sudheer", "Devops Teacher", 130000, true);
            Deconstructors obj2 = new Deconstructors(102, "Eswar", "Testing Teacher", 150000, true);

            (int Id1, string? Name1, string? Designation1, double Salary1, bool Status1) = obj1;
            Console.WriteLine(Id1);
            Console.WriteLine(Name1);
            Console.WriteLine(Designation1);
            Console.WriteLine(Salary1);
            Console.WriteLine(Status1 + "\n");

            var (Id2, Name2, _, Salary2, Status2) = obj2;
            Console.WriteLine(Id2);
            Console.WriteLine(Name2);
            //Console.WriteLine(Designation2);
            Console.WriteLine(Salary2);
            Console.WriteLine(Status2);
        }
    }
}
