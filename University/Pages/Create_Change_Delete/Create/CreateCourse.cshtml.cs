using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Model;
using Microsoft.EntityFrameworkCore;
using University.Data;
using System.Linq;

namespace University.Pages.Create
{
    public class CreateCourseModel : PageModel
    {
        [BindProperty]
        public int Name { get; set; }
        public Course course { get; set; }
        private readonly ApplicationDbContext _context;
        public CreateCourseModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult Onpost()
        {
            //   check if this course already exists?
            course = _context.Course.FirstOrDefault(s => s.Name == Name);
            if (course != null || Name == 0) {return RedirectToPage("/Error"); }  

            //create course
            course = new Course() { Name = Name};
            _context.Course.Add(course);
            _context.SaveChanges();

            return RedirectToPage("/Index", new { course.Name});
        }
    }
}
