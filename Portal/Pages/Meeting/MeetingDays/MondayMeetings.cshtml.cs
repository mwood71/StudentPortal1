using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;

namespace Portal.Pages.Meeting.MeetingDays
{
    //[Authorize(Roles = "Admin,Student")]
    public class MondayMeetingsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public MondayMeetingsModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IList<Models.Meeting> Meetings { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Meetings = await _db.Meetings.Where(a => a.DayOfWeek == "Monday").OrderBy(a=>a.StartTime).ToListAsync();

            return Page();
        }
    }
}
