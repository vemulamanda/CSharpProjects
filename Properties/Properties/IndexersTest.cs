namespace Properties
{
    internal class IndexersTest
    {
        int Id;
        string? Name, Role;
        double Salary;
        bool Status;

        public IndexersTest(int _Id)
        {
            Id= _Id;
            Name = "Sudheer";
            Role = "Devops Engineer";
            Salary = 134000;
            Status = true;
        }

        public object this[int Key]
        {
            get { if (Key == 1)
                    return Name;
                else if (Key == 2)
                    return Role;
                else if (Key == 3)
                    return Salary;
                else if (Key == 4)
                    return Status;
                else
                    return null;
            }
            set { if(Key == 1)
                    Name = (string)value;
                  else if(Key == 2)
                    Role = (string)value;
            }
        }

        static void Main()
        {
            IndexersTest IT = new IndexersTest(101);

            Console.Write("Enter your Lastname: ");
            var E_LastName = Console.ReadLine();
            Console.Write("Enter you Lastname: ");

            IT.Name = "Eswar";
            IT.Role = "Quality Assurance Manager";

            Console.Clear();

            Console.WriteLine("Employee ID is: " + IT[0]);
            Console.WriteLine("Employee ID is: " + IT.Name + " " + E_LastName);
            Console.WriteLine("Employee ID is: " + IT.Role);
            Console.WriteLine("Employee ID is: " + IT[3]);
            Console.WriteLine("Employee ID is: " + IT[4]);

            //Console.ReadLine();
        }
    }
}
