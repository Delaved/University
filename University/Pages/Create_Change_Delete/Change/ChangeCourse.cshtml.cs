using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using University.Data;
using University.Model;

namespace University.Pages.Change
{
    public class ChangeCourseModel : PageModel
    {
        [BindProperty]
        public Course course { get; set; }
        private readonly ApplicationDbContext _context;
        public ChangeCourseModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var serialized—ourse = TempData["course"] as string;
            if (serialized—ourse != null)
            {
                var course = JsonConvert.DeserializeObject<Course>(serialized—ourse);
                this.course = course;
            }
        }
        public IActionResult OnPost() 
        {
            string action = Request.Form["action"];
            if (action == "Choose course")
            {
                return RedirectToPage("/Create_Change_Delete/Choose/Course", "Change");
            }
            else if (action == "Save course")
            {
                _context.Course.Update(course);
                _context.SaveChanges();
            }
            return RedirectToPage("/Index");

        }

    }
}
