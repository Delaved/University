using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Data;
using University.Model;

namespace University.Pages.Lists
{
    public class ListOfSpecializationsModel : PageModel
    {
        public List<Specialization> specializations { get; set; }
        private readonly ApplicationDbContext _context;
        public ListOfSpecializationsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            specializations = _context.Specialization.Select(s => s).ToList();
        }
    }
}
