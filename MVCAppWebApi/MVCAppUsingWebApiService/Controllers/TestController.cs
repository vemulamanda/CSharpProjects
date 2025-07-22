using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCAppUsingWebApiService.Controllers
{
    public class TestController : ApiController
    {
        static List<string> Colors = new List<string>()
        {
            "Red", "Blue", "Green", "Purple", "Magenta"
        };

        public IEnumerable<string> Get()
        {
            return Colors;
        }
        public string Get(int Id)
        {
            return Colors[Id];
        }
        public void Post([FromBody] string Color)
        {
            Colors.Add(Color);
        }
        public void Put(int Id, [FromBody] string Color)
        {
            Colors[Id] = Color;
        }
        public void Delete(int Id)
        {
            Colors.RemoveAt(Id);
        }
    }
}
