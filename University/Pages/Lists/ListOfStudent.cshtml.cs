using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Data;
using University.Model;

namespace University.Pages.Lists
{
    public class ListOfStudentModel : PageModel
    {

        public List<Student> students { get; set; }
        private readonly ApplicationDbContext _context;
        public ListOfStudentModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            students = _context.Student.Select(s => s).ToList();
        }     
    }
}
