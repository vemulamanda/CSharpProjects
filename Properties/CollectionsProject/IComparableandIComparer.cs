namespace CollectionsProject
{
    //Icomparable interface is used to compare values ina array and sort them according to logic
    //written in CompareTo method
    internal class IComparableandIComparer : IComparable<IComparableandIComparer>
    {
        //int S_id, S_class;
        //string? S_name;
        //double S_salary;

        public int Sid { get; set; }
        public string? Name { get; set; }
        public double Salary { get; set; }
        public int Class { get; set; }

        public int CompareTo(IComparableandIComparer? other)
        {
            if(this.Salary > other?.Salary)
                return 1;
            else if(this.Salary < other?.Salary)
                return -1;
            else
                return 0;
        }

        //If we got a class which is written by someone and we need to implement above logic 

        class IComparerTeachers : IComparer<IComparableandIComparer>
        {
            public int Compare(IComparableandIComparer? x, IComparableandIComparer? y)
            {
                if(x?.Sid > y?.Sid)
                    return 1;
                else if(x?.Sid < y?.Sid)
                    return -1;
                else
                    return 0;
            }
        }

        //public static int CompareNames(IComparableandIComparer t1, IComparableandIComparer t2)
        //{
        //    return t1.Name.CompareTo(t2.Name);
        //}
        static void Main()
        {
            IComparableandIComparer s1 = new IComparableandIComparer() { Sid = 108, Name = "sudheer", Salary = 60000, Class = 5 };
            IComparableandIComparer s2 = new IComparableandIComparer() { Sid = 101, Name = "eswar", Salary = 61624, Class = 5 };
            IComparableandIComparer s3 = new IComparableandIComparer() { Sid = 108, Name = "srija", Salary = 60833, Class = 5 };
            IComparableandIComparer s4 = new IComparableandIComparer() { Sid = 107, Name = "siri", Salary = 61000, Class = 5 };
            IComparableandIComparer s5 = new IComparableandIComparer() { Sid = 105, Name = "varma", Salary = 70000, Class = 5 };

            List<IComparableandIComparer> s = new List<IComparableandIComparer>() { s1, s2, s3, s4, s5 };

            IComparerTeachers ICT = new IComparerTeachers();

            //s.Sort(); //This calls IComparable 
            //s.Sort(ICT); //This calls Icomparer 
            //s.Sort(1, 3, ICT); //This calls Icomparer and sorts according to range provided.

            //If you want to pass method to a method (ex: s.Sort(CompareNames);), you should first link 
            //that method to a delegate and then pass that delegate to a method. This is acceptable becoz
            //a delegate is a type and method is member,, i.e, only types can be passed as parameters.

            //Below comparision is pre defined delegate which accepts 2 parameters and we wrote
            //a method named CompareNames matching the signature.

            //Method-01
            //Comparison<IComparableandIComparer> CMP = new Comparison<IComparableandIComparer>(CompareNames);
            //s.Sort(CMP);

            //Method-02 below calls delegate internally which is pre written and that delegate calls method.

            //Method-02
            //s.Sort(CompareNames);

            //In Method-03, We can use anonymous methods also to call a method
            //Method-03
            //s.Sort(delegate(IComparableandIComparer t1, IComparableandIComparer t2) 
            //{
            //    return t1.Name.CompareTo(t2.Name);
            //});

            //In Method-04 , we can do the same using lambda functions also.
            //s.Sort((t1, t2) => t1.Name.CompareTo(t2.Name));

            //Note: In all the above four scenarios, you either specify or interanlly call the comparision delegate only.


            foreach (IComparableandIComparer item in s)
            {
                Console.WriteLine($"{item.Sid} , {item.Name} , {item.Class} , {item.Salary}");
            }
            

        }
    }
}
