using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using University.Data;
using University.Model;

namespace University.Pages.Choose
{
    public class SpecializationModel : PageModel
    {
        public List<Specialization> specializations { get; set; }
        public Record record { get; set; }
        private string previousPage { get; set; }
        private readonly ApplicationDbContext _context;
        public SpecializationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            specializations = _context.Specialization.Select(c => c).ToList();
        }
        public IActionResult OnPost(int id) 
        {
            previousPage = Request.Query["handler"].ToString();
            var specialization = _context.Specialization.FirstOrDefault(s => s.Id == id);
            if (previousPage == "Create")
            {
                var serializedRecord = TempData["record"] as string;
                if (serializedRecord != null)
                {
                    var record = JsonConvert.DeserializeObject<Record>(serializedRecord);
                    this.record = record;
                }
                this.record.Specialization = specialization;
                serializedRecord = JsonConvert.SerializeObject(record);
                TempData["record"] = serializedRecord;
                return RedirectToPage("/Create_Change_Delete/Create/CreateRecord");
            }
            else if(previousPage == "Change")
            {
                TempData["specialization"] = JsonConvert.SerializeObject(specialization);
                return RedirectToPage("/Create_Change_Delete/Change/ChangeSpecialization");
            }
            else if (previousPage == "Change record")
            {
                TempData["specialization"] = JsonConvert.SerializeObject(specialization);
                return RedirectToPage("/Create_Change_Delete/Change/ChangeRecord");
            }
            return RedirectToPage("/Index");
        }
    }
}
