using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portal.Data;
using Portal.Models;

namespace Portal.Pages.MeetAMember
{
    [Authorize(Roles = "Admin,Student")]
    public class CreateCommentModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateCommentModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Comment Comment { get; set; }

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

            _db.Comments.Add(Comment);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
