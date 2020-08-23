using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Data;

namespace Portal.Pages.Meeting.MeetingDays
{
    //[Authorize(Roles = "Admin,Student")]
    public class SundayMeetingsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public SundayMeetingsModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IList<Models.Meeting> Meetings { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Meetings = await _db.Meetings.Where(a => a.DayOfWeek == "Sunday").OrderBy(a => a.StartTime).ToListAsync();

            return Page();
        }
    }
}
