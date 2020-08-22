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
    public class DeleteSignUpModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteSignUpModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Models.Volunteer Volunteer { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Volunteer = await _db.Volunteers.FirstOrDefaultAsync(a => a.Id == id);

            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Volunteers.Remove(Volunteer);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
