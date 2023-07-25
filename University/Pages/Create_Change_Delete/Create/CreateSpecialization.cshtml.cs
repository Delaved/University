using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Model;

namespace University.Pages.Create
{
    public class CreateSpecializationModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        public Specialization? specialization { get; set; }

        private readonly ApplicationDbContext _context;
        public CreateSpecializationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            //   check if this specialization already exists?
            specialization = _context.Specialization.FirstOrDefault(s=> s.Name == Name);
            if (specialization != null) { return RedirectToPage("/Error"); }

            //create specialization
            specialization = new Specialization() { Name = Name};


            _context.Specialization.Add(specialization);
            _context.SaveChanges();

            return RedirectToPage("/Index");

        }
    }
}
