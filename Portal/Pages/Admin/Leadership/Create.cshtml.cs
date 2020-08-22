using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portal.Data;
using Portal.Models;

namespace Portal.Pages.Admin.Leadership
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Models.Leadership Leadership { get; set; }

        public IActionResult OnGet()
        {
            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Leaderships.Add(Leadership);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
