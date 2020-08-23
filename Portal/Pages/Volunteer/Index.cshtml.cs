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

namespace Portal.Pages.Volunteer
{
    //[Authorize(Roles = "Admin,Student")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IList<VolunteerEvent> VolunteerEvents { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            VolunteerEvents = await _db.VolunteerEvents.OrderBy(a=>a.Date).ToListAsync();

            return Page();
        }
    }
}
