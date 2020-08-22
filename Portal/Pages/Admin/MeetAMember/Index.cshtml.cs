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

namespace Portal.Pages.Admin.MeetAMember
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Models.MeetAMember MeetAMember { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            MeetAMember = await _db.MeetAMembers.FirstOrDefaultAsync();

            return Page();
        }
    }
}
