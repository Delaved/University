using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using University.Data;
using University.Model;

namespace University.Pages.Change
{
    public class ChangeRecordModel : PageModel
    {
        [BindProperty]
        public Record record { get; set; }
        private readonly ApplicationDbContext _context;
        public ChangeRecordModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            string rec = TempData["record"] as string;
            if (rec != null)
            {
                record = JsonConvert.DeserializeObject<Record>(rec);
            }
            else
            {
                return;
            }
            string stude = TempData["student"] as string;
            if (stude != null)
            {
                record = JsonConvert.DeserializeObject<Record>(rec);
                record.Student = JsonConvert.DeserializeObject<Student>(stude);
                TempData.Remove("student");
            }
            string cour = TempData["course"] as string;
            if (cour != null)
            {
                record = JsonConvert.DeserializeObject<Record>(rec);
                record.Course = JsonConvert.DeserializeObject<Course>(cour);
                TempData.Remove("course");
            }
            string spec = TempData["specialization"] as string;
            if (spec != null)
            {
                record = JsonConvert.DeserializeObject<Record>(rec);
                record.Specialization = JsonConvert.DeserializeObject<Specialization>(spec);
                TempData.Remove("specialization");
            }
            TempData["record"] = JsonConvert.SerializeObject(record);
            TempData.Keep("record");
        }
        public IActionResult Onpost()
        {
            string action = Request.Form["action"];
            if(action == "Choose record")
            {
                return RedirectToPage("/Create_Change_Delete/Choose/Record", "Change");
            }
            else if (action == "Choose student")
            {
                return RedirectToPage("/Create_Change_Delete/Choose/Student", "Change record");
            }
            else if (action == "Choose course")
            {
                return RedirectToPage("/Create_Change_Delete/Choose/Course", "Change record");
            }
            else if (action == "Choose specialization")
            {
                return RedirectToPage("/Create_Change_Delete/Choose/Specialization", "Change record");
            }
            else if(action == "Save record")
            {
                string rec = TempData["record"] as string;
                if (rec != null)
                {
                    record = JsonConvert.DeserializeObject<Record>(rec);
                }
                _context.Record.Update(record);
                _context.SaveChanges();
                TempData.Remove("record");
            }
            return RedirectToPage("/Index");
        }
    }
}
