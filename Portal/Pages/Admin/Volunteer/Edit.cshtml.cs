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

namespace Portal.Pages.Admin.Volunteer
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public VolunteerEvent VolunteerEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            VolunteerEvent = await _db.VolunteerEvents.FirstOrDefaultAsync(a => a.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var volunteerEventDB = await _db.VolunteerEvents.FirstOrDefaultAsync(a => a.Id == VolunteerEvent.Id);
            volunteerEventDB.Name = VolunteerEvent.Name;
            volunteerEventDB.Description = VolunteerEvent.Description;
            volunteerEventDB.Date = VolunteerEvent.Date;
            volunteerEventDB.StartTime = VolunteerEvent.StartTime;
            volunteerEventDB.EndTime = VolunteerEvent.EndTime;
            volunteerEventDB.Address = VolunteerEvent.Address;
            volunteerEventDB.City = VolunteerEvent.City;
            volunteerEventDB.State = VolunteerEvent.State;
            volunteerEventDB.Zip = VolunteerEvent.Zip;

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");


        }
    }
}
