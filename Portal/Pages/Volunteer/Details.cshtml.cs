using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;
using Portal.Models.ViewModel;

namespace Portal.Pages.Volunteer
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public VolunteerVM VolunteerVM { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            VolunteerVM = new VolunteerVM()
            {
                VolunteerEvent = await _db.VolunteerEvents.FirstOrDefaultAsync(a => a.Id == id),
                VolunteerList = await _db.Volunteers.Where(a => a.VolunteerEventID == id).ToListAsync()
            };

            return Page();
        }
    }
}
