using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portal.Data;
using Portal.Models;

namespace Portal.Pages.Admin.Survey
{
    [Authorize(Roles = "Admin")]
    public class CreateQuestionModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateQuestionModel(ApplicationDbContext db)
        {
            _db = db;       }

        [BindProperty]
        public Questions Questions { get; set; }

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

            _db.Questions.Add(Questions);
            await _db.SaveChangesAsync();

            return RedirectToPage("CreateChoices", new { id = Questions.Id });
        }
    }
}
