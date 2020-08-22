using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;

namespace Portal.Pages.Meeting.MeetingDays
{
    public class TuesdayMeetingsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public TuesdayMeetingsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Models.Meeting> Meetings { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Meetings = await _db.Meetings.Where(a => a.DayOfWeek == "Tuesday").OrderBy(a=>a.StartTime).ToListAsync();

            return Page();
        }
    }
}
