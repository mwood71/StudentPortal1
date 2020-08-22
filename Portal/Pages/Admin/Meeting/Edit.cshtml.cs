using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;

namespace Portal.Pages.Admin.Meeting
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Models.Meeting Meeting { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Meeting = await _db.Meetings.FirstOrDefaultAsync(a => a.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var meetingDB = await _db.Meetings.FirstOrDefaultAsync(a => a.Id == Meeting.Id);
            meetingDB.Name = Meeting.Name;
            meetingDB.DayOfWeek = Meeting.DayOfWeek;
            meetingDB.StartTime = Meeting.StartTime;
            meetingDB.EndTime = Meeting.EndTime;
            meetingDB.Address = Meeting.Address;
            meetingDB.City = Meeting.City;
            meetingDB.State = Meeting.State;
            meetingDB.Zip = Meeting.Zip;

            await _db.SaveChangesAsync();

            return RedirectToPage("Index"); 
        }
    }
}
