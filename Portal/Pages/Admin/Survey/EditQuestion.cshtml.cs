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

namespace Portal.Pages.Admin.Survey
{
    [Authorize(Roles = "Admin")]
    public class EditQuestionModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditQuestionModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Questions Questions { get; set; }

        public async Task<IActionResult> OnGetAsync( int id)
        {
            Questions = await _db.Questions.FirstOrDefaultAsync(a => a.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var questionDB = await _db.Questions.FirstOrDefaultAsync(a => a.Id == Questions.Id);
            questionDB.Question = Questions.Question;

            await _db.SaveChangesAsync();

            return RedirectToPage("EditChoices", new { id = Questions.Id });
        }
    }
}
