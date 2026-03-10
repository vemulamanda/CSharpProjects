using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudMauiApp.Models
{
    internal class ErrorResponse
    {
        public string error_msg { get; set; }
        public Dictionary<string, string[]> errors { get; set; }
    }
}
