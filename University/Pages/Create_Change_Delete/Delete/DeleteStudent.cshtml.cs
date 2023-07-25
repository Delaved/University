using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Data;
using University.Model;

namespace University.Pages.Delete
{
    public class DeleteStudentModel : PageModel
    {
        public List<Student> students { get; set; }
        private readonly ApplicationDbContext _context;
        public DeleteStudentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            students = _context.Student.Select(r => r).ToList();
        }
        public IActionResult OnPost(int id)
        {
            var student = _context.Student.Find(id);
            if (student != null)
            {
                var records = _context.Record.Where(r => r.StudentId == id);
                if (records != null)
                {
                    _context.Record.RemoveRange(records);
                }
                _context.Student.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToPage("/Create_Change_Delete/Delete/DeleteStudent");
        }
    }
}
