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

namespace Portal.Pages.Meeting
{
    //[Authorize(Roles = "Admin,Student")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Models.Meeting> Meetings { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Meetings = await _db.Meetings.OrderBy(a => a.StartTime).ToListAsync();

            return Page();
        }
    }
}
