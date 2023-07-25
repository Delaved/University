using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Data;
using University.Model;

namespace University.Pages.Delete
{
    public class DeleteCourseModel : PageModel
    {
        public List<Course> courses { get; set; }
        private readonly ApplicationDbContext _context;
        public DeleteCourseModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            courses = _context.Course.Select(r => r).ToList();
        }
        public IActionResult OnPost(int id)
        {
            var course = _context.Course.Find(id);
            if (course != null)
            {
                var records = _context.Record.Where(r => r.CourseId == id);
                if (records != null)
                {
                    _context.Record.RemoveRange(records);
                }
                _context.Course.Remove(course);
                _context.SaveChanges();
            }
            return RedirectToPage("/Create_Change_Delete/Delete/DeleteCourse");
        }
    }
}
