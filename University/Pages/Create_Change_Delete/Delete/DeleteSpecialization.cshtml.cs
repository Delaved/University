using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Data;
using University.Model;

namespace University.Pages.Delete
{
    public class DeleteSpecializationModel : PageModel
    {
        public List<Specialization> specializations { get; set; }
        private readonly ApplicationDbContext _context;
        public DeleteSpecializationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            specializations = _context.Specialization.Select(r => r).ToList();
        }
        public IActionResult OnPost(int id)
        {
            var specialization = _context.Specialization.Find(id);
            if (specialization != null)
            {
                var records = _context.Record.Where(r => r.SpecializationId == id);
                if (records != null)
                {
                    _context.Record.RemoveRange(records);
                }
                _context.Specialization.Remove(specialization);
                _context.SaveChanges();
            }
            return RedirectToPage("/Create_Change_Delete/Delete/DeleteSpecialization");
        }
    }
}
