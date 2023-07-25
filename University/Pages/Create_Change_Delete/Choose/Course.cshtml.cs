using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Pages.Create;
using University.Model;
using Microsoft.EntityFrameworkCore;
using University.Data;
using Newtonsoft.Json;

namespace University.Pages.Choose
{
    public class CourseModel : PageModel
    {
        public List<Course> courses { get; set; }
        public Record record { get; set; }
        private string previousPage { get; set; }
        private readonly ApplicationDbContext _context;
        public CourseModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            //   get list of courses
            courses = _context.Course.Select(s =>s).ToList();   
        }

        public IActionResult OnPost(int id)
        {
            previousPage = Request.Query["handler"].ToString();
            var course = _context.Course.FirstOrDefault(s => s.Id == id);
            if (previousPage == "Create")
            {
                var serializedRecord = TempData["record"] as string;
                if (serializedRecord != null)
                {
                    var record = JsonConvert.DeserializeObject<Record>(serializedRecord);
                    this.record = record;
                }
                this.record.Course = course;
                serializedRecord = JsonConvert.SerializeObject(record);
                TempData["record"] = serializedRecord;
                return RedirectToPage("/Create_Change_Delete/Create/CreateRecord");
            }
            else if(previousPage == "Change")
            {
                var serializedCourse = TempData["course"] as string;
                serializedCourse = JsonConvert.SerializeObject(course);
                TempData["course"] = serializedCourse;
                return RedirectToPage("/Create_Change_Delete/Change/ChangeCourse");
            }
            else if (previousPage == "Change record")
            {
                var serializedCourse = TempData["course"] as string;
                serializedCourse = JsonConvert.SerializeObject(course);
                TempData["course"] = serializedCourse;
                return RedirectToPage("/Create_Change_Delete/Change/ChangeRecord");
            }

            return RedirectToPage("/Index");
            //this work
            //var course = _context.Course.FirstOrDefault(s => s.Id == id);
            //var serialized—ourse = JsonConvert.SerializeObject(course);
            //TempData["course"] = serialized—ourse;
            //return RedirectToPage("/Create/CreateRecord");
        }
    }
}
