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

namespace Portal.Pages.Leadership
{
    //[Authorize(Roles = "Admin,Student")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Models.Leadership> LeadershipList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            LeadershipList = await _db.Leaderships.ToListAsync();

            return Page();
        }
    }
}
