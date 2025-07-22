namespace Properties
{
    internal class CustomerTest
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Customer C = new Customer(105);
            Console.WriteLine("Customer ID is: " + C.CustID);

            if (C.Status)
                Console.WriteLine("The customer status is Active");
            else
                Console.WriteLine("The customer status is inactive.");

            Console.WriteLine("The customer name is : " + C.Name);
            Console.WriteLine("The customer balance is: " + C.Balance);
            C.City = Cities.Rajamaundry;
            Console.WriteLine(C.City);

            //C.State = "Andhra Pradesh";
            Console.WriteLine("The state is : " + C.State);

            //C.Country = "Australia";
            Console.WriteLine("The state is : " + C.Country);
            Console.WriteLine("The state is : " + C.Continent);
        }
    }
}
