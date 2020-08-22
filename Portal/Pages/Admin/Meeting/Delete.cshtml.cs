using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Data;

namespace Portal.Pages.Admin.Meeting
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Models.Meeting Meeting { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Meeting = await _db.Meetings.FirstOrDefaultAsync(a => a.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Meetings.Remove(Meeting);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
