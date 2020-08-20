using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;
using Portal.Models.ViewModel;

namespace Portal.Pages.Survey
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public QuestionChoicesVM QuestionChoicesVM { get; set; }
        [BindProperty]
        public Answers Answers { get; set; }

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
