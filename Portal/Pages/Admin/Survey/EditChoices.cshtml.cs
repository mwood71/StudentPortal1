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
    public class EditChoicesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditChoicesModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Choices Choices { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Choices = await _db.Choices.FirstOrDefaultAsync(a => a.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var choicesDB = await _db.Choices.FirstOrDefaultAsync(a => a.Id == Choices.Id);
            choicesDB.Choice1 = Choices.Choice1;
            choicesDB.Choice2 = Choices.Choice2;
            choicesDB.Choice3 = Choices.Choice3;
            choicesDB.Choice4 = Choices.Choice4;
            choicesDB.Choice5 = Choices.Choice5;
            choicesDB.Choice6 = Choices.Choice6;

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
