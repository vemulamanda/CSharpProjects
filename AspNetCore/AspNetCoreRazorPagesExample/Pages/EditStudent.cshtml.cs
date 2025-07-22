using AspNetCoreRazorPagesExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreRazorPagesExample.Pages
{
    public class EditStudentModel : PageModel
    {
        private readonly MvcdbContext context;

        public EditStudentModel(MvcdbContext context)
        {
            this.context = context;
        }

        public Student Student { get; set; }
        public void OnGet(int Sid)
        {
            Student = context.Students.Find(Sid);
        }

        public RedirectResult OnPost(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
            return Redirect("Index");
        }
    }
}
