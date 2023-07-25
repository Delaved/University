using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using University.Data;
using University.Model;

namespace University.Pages.Choose
{
    public class RecordModel : PageModel
    {
        public List<Record> records { get; set; }
        private readonly ApplicationDbContext _context;
        private string previousPage;
        public RecordModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            records = _context.Record.Include(r => r.Course).Include(r => r.Specialization).Include(r => r.Student).ToList();
        }
        public IActionResult OnPost(int id)
        {
            previousPage = Request.Query["handler"].ToString();
            var record = _context.Record.Include(r => r.Course).Include(r => r.Specialization).Include(r => r.Student).FirstOrDefault(s => s.Id == id);
            if (previousPage == "Change")
            {
                var serializedRecord = TempData["record"] as string;
                serializedRecord = JsonConvert.SerializeObject(record);
                TempData["record"] = serializedRecord;
                return RedirectToPage("/Create_Change_Delete/Change/ChangeRecord");
            }

            return RedirectToPage("/Index");
        }
    }
}
