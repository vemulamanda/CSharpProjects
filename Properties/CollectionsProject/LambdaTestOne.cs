namespace CollectionsProject
{
    internal class LambdaTestOne
    {
        //Fields:
        int ID;
        string? Name;

        //Constructor
        public LambdaTestOne(int ID, string name) 
        {
            this.ID = ID;
            this.Name = name;
        }

        //Finalizer
        ~LambdaTestOne() 
        {
            Console.WriteLine("Instance is destroyed");
        }
        //properties
        public int _ID
        {
            get { return ID; }
        }
        public string? _Name
        {
            get { return Name; }
            set { Name = value; }
        }
        //Method:
        public void GetName()
        {
            Console.WriteLine($"The Name is: {Name}");
        }
        //Deconstructor
        public void deconstruct(out int ID, out string? Name)
        {
            ID = this.ID;
            Name = this.Name;
        }
        static void Main()
        {
            LambdaTestOne LTO = new LambdaTestOne(101, "Sudheer");
            Console.WriteLine("The output is: " + LTO.ID + " " + LTO.Name);
            LTO.GetName();
        }
    }

    internal class LambdaTestTwo
    {
        int ID;
        string? Name;

        //Constructor C# 7.0
        public LambdaTestTwo(int _ID) => ID = _ID;
        //Finalizer C# 7.0
        ~LambdaTestTwo() => Console.WriteLine("Instance is destroyed");
        //properties C# 7.0
        public int _ID => ID;
        public string? _Name
        {
            get => Name;
            set => Name = value;
        }

        //Method C# 6.0
        public void GetName() => Console.WriteLine($"The Name is: {Name}");

        //Deconstructor C# 7.0
        public void Deconstruct(out int ID) => ID = _ID;

    }
}


