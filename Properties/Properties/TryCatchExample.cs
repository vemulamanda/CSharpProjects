namespace Properties
{
    public class DivideByOddNumException: ApplicationException
    {
        public override string Message
        {
            get { return "You cannot divide by odd number. From sudheer."; }
        }
    }
    internal class TryCatchExample
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter 1st number: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Enter 2nd number: ");
                int y = int.Parse(Console.ReadLine());
                if(y % 2 > 0)
                {
                    //throw new ApplicationException();
                    //throw new ApplicationException("Please enter only odd number.");
                    throw new DivideByOddNumException();
                }
                int z = x / y;
                Console.WriteLine("The value of divisor is: " + z);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("The number cant be divided by zero bro.");
            }
            catch (FormatException)
            {
                Console.WriteLine("You can only enter integers bro..");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            finally
            {
                Console.WriteLine("This is final block got executed.");
            }
        }
    }
}
