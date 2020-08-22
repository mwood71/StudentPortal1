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

namespace Portal.Pages.MeetAMember
{
    [Authorize(Roles = "Admin,Student")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public MeetAMemberCommentVM VM { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            VM = new MeetAMemberCommentVM()
            {
                MeetAMember = await _db.MeetAMembers.FirstOrDefaultAsync(),
                CommentList = await _db.Comments.ToListAsync()
            };

            return Page();
        }
    }
}
