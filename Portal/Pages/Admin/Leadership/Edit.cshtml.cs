using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;

namespace Portal.Pages.Admin.Leadership
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Models.Leadership Leadership { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Leadership = await _db.Leaderships.FirstOrDefaultAsync(a => a.Id == id);

            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var leadershipDB = await _db.Leaderships.FirstOrDefaultAsync(a => a.Id == Leadership.Id);
            leadershipDB.Name = Leadership.Name;
            leadershipDB.Position = Leadership.Position;
            leadershipDB.url = Leadership.url;

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");

        }
    }
}
