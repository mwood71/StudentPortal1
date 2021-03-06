using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models.ViewModel;

namespace Portal.Pages.Admin.Survey
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public QuestionChoicesVM QuestionChoicesVM { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            QuestionChoicesVM = new QuestionChoicesVM()
            {
                Questions = await _db.Questions.ToListAsync(),
                Choices = await _db.Choices.ToListAsync()
            };

            return Page();
        }
    }
}
