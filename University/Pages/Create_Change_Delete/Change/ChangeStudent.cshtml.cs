using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using University.Data;
using University.Model;

namespace University.Pages.Change
{
    public class ChangeStudentModel : PageModel
    {
        [BindProperty]
        public Student student { get; set; }
        private readonly ApplicationDbContext _context;
        public ChangeStudentModel(ApplicationDbContext context)
        {
            _context= context;
        }
        public void OnGet()
        {
            var seriliazationStundet = TempData["student"] as string;
            if(seriliazationStundet != null) 
            {
                student = JsonConvert.DeserializeObject<Student>(seriliazationStundet);
            }
        }
        public IActionResult OnPost()
        {
            string action = Request.Form["action"];
            if(action == "Choose student")
            {
                return RedirectToPage("/Create_Change_Delete/Choose/Student", "Change");
            }
            else if(action == "Change student")
            {
                _context.Student.Update(student);
                _context.SaveChanges();
            }

            return RedirectToPage("/Index");
        }

    }
}
