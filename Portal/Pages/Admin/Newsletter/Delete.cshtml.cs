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

namespace Portal.Pages.Admin.Newsletter
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Models.Newsletter Newsletter { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Newsletter = await _db.Newsletters.FirstOrDefaultAsync(a => a.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Newsletters.Remove(Newsletter);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
