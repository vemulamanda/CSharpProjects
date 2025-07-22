namespace CSharpTestingProject
{
    internal class PizzaStore : Pizza
    {
        public static int Pizza_Id;

        static void Main()
        {
            Pizza P = new Pizza();
            while (P.isValid)
            {
                P.DisplayPizzaMenu();

                Console.WriteLine();
                Console.Write("Please select the number of your pizza: ");

                string? PID = Console.ReadLine();
                if (int.TryParse(PID, out int pid) && pid >= 1 && pid <= 6)
                {
                    P.isValid = true;
                    P.AddToCart(pid);

                    P.Confirmation();
                    
                    Console.WriteLine();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"Please enter correct pizza number.\n\n");
                }
            }

            P.Checkout();
            


            Console.ReadLine();
        }
    }
}
