using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Data;
using University.Model;

namespace University.Pages.Lists
{
    public class ListOfCoursetModel : PageModel
    {
        public List<Course> courses { get; set; }
        private readonly ApplicationDbContext _context;
        public ListOfCoursetModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            //   get list of courses
            courses = _context.Course.Select(s => s).ToList();
        }
    }
}
