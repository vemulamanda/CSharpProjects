using AspNetCoreRazorPagesExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreRazorPagesExample.Pages
{
    public class AddStudentModel : PageModel
    {
        private readonly MvcdbContext context;

        public AddStudentModel(MvcdbContext context)
        {
            this.context = context;
        }

        public Student Student { get; set; }
        public void OnGet()
        {
        }

        public RedirectResult OnPost(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return Redirect("Index");
        }
    }
}
