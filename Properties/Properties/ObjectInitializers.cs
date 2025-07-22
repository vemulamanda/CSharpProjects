namespace Properties
{
    internal class ObjectInitializers
    {
        int S_ID;
        string? S_Name;
        int S_Class;
        double S_Marks, S_Fees;

        public override string ToString()
        {
            return "Student ID: " + S_ID + "\nStudent Name: " + S_Name + "\nStudent Class: " + S_Class + "\nStudent Marks: " + S_Marks + "\nStudent Fees: " + S_Fees; 
        }  


        static void Main()
        {
            ObjectInitializers OI1 = new ObjectInitializers { S_ID = 101, S_Name = "Eswar", S_Class = 10, S_Marks = 96.54f, S_Fees = 59000.99f };
            ObjectInitializers OI2 = new ObjectInitializers { S_ID = 102, S_Name = "Sudheer", S_Class = 8 };
            Console.WriteLine(OI1);
            Console.WriteLine();
            Console.WriteLine(OI2);
        }
    }
}
