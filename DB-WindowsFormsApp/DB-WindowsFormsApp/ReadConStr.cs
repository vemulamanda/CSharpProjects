using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DB_WindowsFormsApp
{
    internal class ReadConStr
    {
        public static string SConStr
        {
            get { return ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString; }
        }
        public static string EConStr
        {
            get { return ConfigurationManager.ConnectionStrings["ExcelConStr"].ConnectionString; }
        }
    }
}
