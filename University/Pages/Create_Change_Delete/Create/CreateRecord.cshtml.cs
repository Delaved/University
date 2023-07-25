using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using University.Data;
using University.Model;

namespace University.Pages.Create
{
    [BindProperties]
    public class CreateRecordModel : PageModel
    {
        //public Student? student { get; set; }
        //public Course? course { get; set; }
        //public Specialization? specialization { get; set; }
        public Record? record { get; set; }

        private readonly ApplicationDbContext _context;
        public CreateRecordModel(ApplicationDbContext context)
        {
            _context= context;
        }

        public void OnGet()
        {
            var serializedRecord = TempData["record"] as string;
            if (serializedRecord != null)
            {
                var record = JsonConvert.DeserializeObject<Record>(serializedRecord);
                this.record = record;
                this.record.Id = 0;
                TempData["record"] = JsonConvert.SerializeObject(this.record);
            }
        }

        public IActionResult OnPost() 
        {

            string action = Request.Form["action"];
            if (action == "Choose student")
            {
                return RedirectToPage("/Create_Change_Delete/Choose/Student", "Create");
            }
            else if (action == "Choose course")
            {
                return RedirectToPage("/Create_Change_Delete/Choose/Course", "Create");
            }
            else if (action == "Choose Specialization")
            {
                return RedirectToPage("/Create_Change_Delete/Choose/Specialization", "Create");
            }
            else if (action == "Save record")
            {
                var serializedRecord = TempData["record"] as string;
                if (serializedRecord != null)
                {
                    var recordfromJson = JsonConvert.DeserializeObject<Record>(serializedRecord);
                    record = recordfromJson;
                    _context.Record.Add(record);
                    //that means we dont write new line to the tables Specialization/ Course/Student
                    _context.Entry(record.Specialization).State = EntityState.Modified;
                    _context.Entry(record.Course).State = EntityState.Modified;
                    _context.Entry(record.Student).State = EntityState.Modified;
                    _context.SaveChanges();
                    TempData.Remove("record");
                }
            }
            return RedirectToPage("/Index");
        }
    }
}
