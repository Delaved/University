using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using University.Data;
using University.Model;

namespace University.Pages.Change
{
    public class ChangeSpecializationModel : PageModel
    {
        [BindProperty]
        public Specialization specialization { get; set; }
        private readonly ApplicationDbContext _context;
        public ChangeSpecializationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var serelizationSpecialization = TempData["specialization"] as string;
            if (serelizationSpecialization != null)
            {
                var specialization = JsonConvert.DeserializeObject<Specialization>(serelizationSpecialization);
                this.specialization = specialization;
            }
        }
        public IActionResult OnPost()
        {
            string action = Request.Form["action"];
            if (action == "Choose specialization")
            {
                return RedirectToPage("/Create_Change_Delete/Choose/Specialization", "Change");
            }
            else if (action == "Save specialization")
            {
                _context.Specialization.Update(specialization);
                _context.SaveChanges();
            }

            return RedirectToPage("/Index");
        }
    }
}
