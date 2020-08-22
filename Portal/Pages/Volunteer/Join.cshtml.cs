using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;

namespace Portal.Pages.Volunteer
{
    public class JoinModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public JoinModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Models.Volunteer Volunteers { get; set; }

        public IActionResult OnGet(int id)
        {
            Volunteers = new Models.Volunteer();
            Volunteers.VolunteerEventID = id;

            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Volunteers.Add(Volunteers);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
