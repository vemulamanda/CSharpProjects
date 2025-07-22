using AspNetCoreRazorPagesExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreRazorPagesExample.Pages
{
    public class DeleteStudentModel : PageModel
    {
        public Student Student { get; set; }
        private readonly MvcdbContext context;

        public DeleteStudentModel(MvcdbContext context)
        {
            this.context = context;
        }
        public void OnGet(int Sid)
        {
            Student = context.Students.Find(Sid);
        }

        public RedirectResult OnPost()
        {
            Student.Status = false;
            context.Students.Update(Student);
            context.SaveChanges();

            return Redirect("Index");
        }
    }
}
