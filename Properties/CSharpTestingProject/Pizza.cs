using System.Collections;
using System.Runtime.CompilerServices;

namespace CSharpTestingProject
{
    internal class Pizza
    {
        public int Final_Price = 0;
        string? F_name, Email, Mobile;

        public bool isValid = true;

        private static ArrayList Cart = new ArrayList();
        //private static List<int> SelectedPrice = new List<int>();
        private static Hashtable HT = new Hashtable();
        //Dictionary is best when you need to access values using key value pairs.(like use product id to get product name)
        private static Dictionary<int, (string PizzaName, int Price)> PizzaDictionary = new Dictionary<int, (string PizzaName, int Price)>
        {
            { 1, ("Peri Peri Pizza", 23) },
            { 2, ("Mushroom Pizza", 24) },
            { 3, ("Chicken Pizza", 25) },
            { 4, ("Burger Pizza", 26) },
            { 5, ("Veg Pizza", 27) },
            { 6, ("Butter Chicken Pizza", 28) }
        };

        /*public bool Valid
        {
            get { return isValid; }
            set { isValid = value; }
        }*/

        public void DisplayPizzaMenu()
        {
            foreach (var item in PizzaDictionary)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{item.Key} = {item.Value.PizzaName} - {item.Value.Price}$");
            }
        }

        public void AddToCart(int pid)
        {
            var (PizzaName, Price) = PizzaDictionary[pid];
            Console.WriteLine($"You selected {PizzaName} and price is {Price}");
            Cart.Add($"You selected: {pid} = {PizzaName} {Price}$");
            HT.Add(pid, Price);
            Final_Price += Price;
        }

        public void Confirmation()
        {
            Console.Write("Do you want to add more pizzas. Please press Y/N: ");

            string? confirmation = Console.ReadLine();
            if (confirmation == "Y" || confirmation == "y")
            {
                Console.Clear();
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var item in Cart)
                {
                     Console.WriteLine($"Current item in your cart: {item}");
         
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Green;

                return;

            }
            else if (confirmation == "N" || confirmation == "n")
            {
                Console.Clear();
                isValid = false;
                DisplayCart();
                return;
               
            }
            else
            {
                Console.WriteLine("Please enter only Y/y or N/n");
                Confirmation();
            }
        }

        public void DisplayCart()
        {
            
            Console.WriteLine("Please check your order.\n");

            Console.WriteLine($"Your Selected items are: \n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in Cart)
            {
                Console.WriteLine($"Current item in your cart: {item}");
            }
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();
        }

        public void FinalOrderCheck()
        {
            Console.WriteLine("Please check your order.\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Customer Name: {HT["Name"]}\nMobile Number: {HT["Mobile Number"]}\nEmail ID: {HT["Email ID"]}");

            DisplayCart();

            Console.WriteLine($"Your Final price is: {Final_Price}$");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void EnterUserDetails()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You have confirmed the checkout.\n\n");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Please enter your details Below.\n");

            Console.Write("Please enter your Name: ");
            F_name = Console.ReadLine();
            HT.Add("Name", F_name);
            Console.Write("Please enter your Mobile Number: ");
            Mobile = Console.ReadLine();
            HT.Add("Mobile Number", Mobile);
            Console.Write("Please enter your Email ID: ");
            Email = Console.ReadLine();
            HT.Add("Email ID", Email);
            Console.WriteLine();
        }

        public void Payment()
        {
            Console.Write("\nPlease enter 'PAY' to pay for the food (Enter 'PAY'): ");
            string? Pay = Console.ReadLine();

            if (Pay == "PAY")
            {
                Console.WriteLine("\n\nTHANK YOU FOR THE PAYMENT. YOUR FOOD IS GETTING READY IN THE KITCHEN NOW.");
                Console.WriteLine("\nTHANK YOU FOR USING OUR PIZZA APP. SEE YOU NEXT TIME. BYE..");
            }
        }

        public void Checkout()
        {
            bool Checkout_Con = true;

            while (Checkout_Con)
            {
                Console.Clear();

                DisplayCart();
                Console.Write($"Do you want to checkout or edit your order? (Enter 'Y' - To Checkout / 'N' - Edit your order): ");
                string? Checkout_Confirm = Console.ReadLine();

                if (Checkout_Confirm == "Y" || Checkout_Confirm == "y")
                {
                    Checkout_Con = false;
                    EnterUserDetails();

                    FinalOrderCheck();

                    Payment();
                }
                else if (Checkout_Confirm == "N" || Checkout_Confirm == "n")
                {
                    Checkout_Con = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You have chosen to edit your order.\n\n");
                    Console.ForegroundColor = ConsoleColor.Green;

                    bool EditConfirmation = true;

                    while (EditConfirmation)
                    {
                        
                        //DisplayCart();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\nPlease select a pizza number to remove: ");
                        Console.ForegroundColor = ConsoleColor.Green;

                        string? RP_No = Console.ReadLine();

                        if (int.TryParse(RP_No, out int Remove_Pizza_No))
                        {
                            Console.Clear();
                            DisplayCart();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("We have not found the pizza id you entered. Please select the ID only from the list displayed above.\n ");
                            Console.ForegroundColor = ConsoleColor.Green;

                            if (HT.ContainsKey(Remove_Pizza_No))
                            {
                                Console.WriteLine($"\nYou removed: {HT[Remove_Pizza_No]}");

                                for (int i = Cart.Count - 1; i >= 0; i--)
                                {
                                    if (Cart[i] is string item && item.Contains(Remove_Pizza_No + " = "))
                                    {
                                        Cart.RemoveAt(i);
                                    }
                                }
                                Console.Clear();

                                Final_Price = Final_Price - Convert.ToInt32(HT[Remove_Pizza_No]);


                                HT.Remove(Remove_Pizza_No);

                                Console.WriteLine();
                                DisplayCart();

                                Console.Write("Are you done Editing your cart (Enter Y/N): ");
                                string? EditedToYes = Console.ReadLine();

                                if (EditedToYes == "Y" || EditedToYes == "y")
                                {
                                    Console.WriteLine("Please proceed to checkout.. Thank you..");
                                    EditConfirmation = false;
                                    Console.Clear();

                                    EnterUserDetails();

                                    FinalOrderCheck();

                                    Payment();
                                }
                                else if (EditedToYes == "N" || EditedToYes == "n")
                                {
                                    Console.WriteLine("Please continue with editing..");
                                }
                                else
                                {
                                    Console.WriteLine("Please enter only Y or y/N or n");
                                }
                                //}
                                //else if (!HT.ContainsKey(Remove_Pizza_No))
                                //{
                                //Console.WriteLine("We have not found the pizza id you entered. Please select the ID only from the list displayed above.");
                                // }
                            }
                        }
                    }
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter Y/N.");
                }
            }
        }
    }
}
