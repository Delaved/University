using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using University.Data;
using University.Model;
using Microsoft.EntityFrameworkCore;

namespace University.Pages.Create_Change_Delete.Delete
{
    public class DeleteRecordModel : PageModel
    {
        public List<Record> records { get; set; }
        private readonly ApplicationDbContext _context;
        public DeleteRecordModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            records = _context.Record.Include(r => r.Course).Include(r => r.Specialization).Include(r => r.Student).ToList();
        }
        public IActionResult OnPost(int id)
        {
            var record = _context.Record.Find(id);
            if (record != null)
            {
                _context.Record.Remove(record);
                _context.SaveChanges();
            }
            return RedirectToPage("/Create_Change_Delete/Delete/DeleteRecord");
        }
    }
}
