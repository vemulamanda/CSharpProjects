using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudMauiApp.Models
{
    public class LoginResponse
    {
        // Define a class to deserialize the login response
            public string? token { get; set; }
            public string? identity { get; set; }
            public string? userId { get; set; }
    }
}
