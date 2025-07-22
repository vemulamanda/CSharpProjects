using AspNetCoreRazorPagesExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreRazorPagesExample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MvcdbContext _context;

        public IndexModel(ILogger<IndexModel> logger, MvcdbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Student> Students { get; set; }
        public void OnGet()
        {
            Students = _context.Students.Where(S => S.Status == true).ToList();
        }
        public void OnPost()
        {

        }
    }
}
