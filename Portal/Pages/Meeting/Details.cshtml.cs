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

namespace Portal.Pages.Meeting
{
    //[Authorize(Roles = "Admin,Student")]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
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
    }
}
