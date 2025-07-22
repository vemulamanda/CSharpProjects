using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    internal class StringBuilder
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            string s = "";

            for(int i=1; i<100;i++)
            {
                s = s + 1;
            }
            
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i + 1);
            }
        }
        
    }
}
