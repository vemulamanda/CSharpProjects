namespace CollectionsProject
{
    //MultiCast delegate: In these delegates multiple methods can be assigned to single delegate.
    //But the rule is the method has be non value returning type and same parameter types(signature) should be passed.
    internal class DelegatesExampleTwo
    {
        public void Add(int a, int b, int c)
        {
            Console.WriteLine($"The addition is: {a + b + c}");
        }
        public void Sub(int a, int b, int c)
        {
            Console.WriteLine($"The addition is: {a - b - c}");
        }
        public void Mul(int a, int b, int c)
        {
            Console.WriteLine($"The addition is: {a * b * c}");
        }
        public void Div(int a, int b, int c)
        {
            Console.WriteLine($"The addition is: {a / b / c}");
        }

        public string GoodMorning(string str)
        {
            return $"Hello {str}. Good Morning.";
        }
        static void Main()
        {
            DelegatesExampleTwo DET = new DelegatesExampleTwo();
            CalcDelegate CD = new CalcDelegate(DET.Add);
            CD += DET.Sub; CD += DET.Mul; CD += DET.Div;

            CD(1545, 232, 3784);
            Console.WriteLine();
            CD(11, 22, 33);

            SayHelloDelegate SHD = new SayHelloDelegate(DET.GoodMorning);
            Console.WriteLine(SHD("Sudheer"));
        }
    }
}
