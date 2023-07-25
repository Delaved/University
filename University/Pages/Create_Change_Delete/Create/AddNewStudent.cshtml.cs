using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Model;
using Microsoft.EntityFrameworkCore;
using University.Data;
using Microsoft.AspNetCore.Components.Web;

namespace University.Pages.Create
{
    public class AddNewStudentModel : PageModel
    {
        [BindProperty]
        public Student student { get; set; }
        private readonly ApplicationDbContext _context;
        public AddNewStudentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            //student = new Student();

            if (string.IsNullOrWhiteSpace(student.Name)) student.Name = "Default";
            if (string.IsNullOrWhiteSpace(student.LastName)) student.LastName = "Default";
            if (string.IsNullOrWhiteSpace(student.Patronymic)) student.Patronymic = "Default";
            _context.Student.Add(student);
            _context.SaveChanges();

            return RedirectToPage("/Index", new { student.Name, student.LastName });
        }
    }
}
