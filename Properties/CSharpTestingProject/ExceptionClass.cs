namespace CSharpTestingProject
{
    internal class ExceptionClass : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "Please enter the correct pizza number.";
            }
        }
    }
}
