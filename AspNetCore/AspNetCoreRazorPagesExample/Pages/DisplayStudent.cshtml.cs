using AspNetCoreRazorPagesExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreRazorPagesExample.Pages
{
    public class DisplayStudentModel : PageModel
    {
        private readonly MvcdbContext context;

        public DisplayStudentModel(MvcdbContext context)
        {
            this.context = context;
        }
        public Student Student { get; set; }
        public void OnGet(int Sid)
        {
            Student = context.Students.Find(Sid);
        }
    }
}
