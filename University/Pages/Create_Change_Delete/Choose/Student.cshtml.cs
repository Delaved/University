using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Pages.Create;
using University.Model;
using Microsoft.EntityFrameworkCore;
using University.Data;
using Newtonsoft.Json;

namespace University.Pages.Choose
{
    public class StudentModel : PageModel
    {
        public List<Student> students { get; set; }
        public Record? record { get; set; }
        private string previousPage { get; set; }
        private readonly ApplicationDbContext _context;
        public StudentModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            //   get list of students
            students = _context.Student.Select(s =>s).ToList();
        }

        public IActionResult OnPost(int id)
        {
            previousPage = Request.Query["handler"].ToString();
            var student = _context.Student.FirstOrDefault(s => s.Id == id);
            if (previousPage == "Create")
            {
                var serializedRecord = TempData["record"] as string;
                if (serializedRecord != null)
                {
                    var record = JsonConvert.DeserializeObject<Record>(serializedRecord);
                    this.record = record;
                }
                else
                {
                    record = new Record();
                }
                record.Student = student;
                serializedRecord = JsonConvert.SerializeObject(record);
                TempData["record"] = serializedRecord;
                return RedirectToPage("/Create_Change_Delete/Create/CreateRecord");
            }
            else if(previousPage == "Change")
            {
                TempData["student"] = JsonConvert.SerializeObject(student);
                return RedirectToPage("/Create_Change_Delete/Change/ChangeStudent");
                
            }
            else if (previousPage == "Change record")
            {
                TempData["student"] = JsonConvert.SerializeObject(student);
                return RedirectToPage("/Create_Change_Delete/Change/ChangeRecord");
            }
            return RedirectToPage("/Index");


            //var student = _context.Student.FirstOrDefault(s => s.Id == id);
            //record.student = student;
            //var serializedStudent = JsonConvert.SerializeObject(student);
            //TempData["student"] = serializedStudent;
            //return RedirectToPage("/Create/CreateRecord");
        }
    }
}
