using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Model;

namespace University.Pages.Lists
{
    public class ListOfRecordModel : PageModel
    {
        public List<Record> records { get; set; }
        private readonly ApplicationDbContext _context;
        public ListOfRecordModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            records = _context.Record.Include(r => r.Course).Include(r => r.Specialization).Include(r => r.Student).ToList();
        }
    }
}
