using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;

namespace Portal.Pages.Admin.Survey
{
    public class CreateChoicesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateChoicesModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Choices Choices { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Choices = new Choices();
            Choices.QuestionID = id;
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Choices.Add(Choices);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
