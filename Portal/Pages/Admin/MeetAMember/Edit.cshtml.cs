using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;

namespace Portal.Pages.Admin.MeetAMember
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Models.MeetAMember MeetAMember { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            MeetAMember = await _db.MeetAMembers.FirstOrDefaultAsync(a => a.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var meetAMemberDB = await _db.MeetAMembers.FirstOrDefaultAsync(a => a.Id == MeetAMember.Id);
            meetAMemberDB.Title = MeetAMember.Title;
            meetAMemberDB.Author = MeetAMember.Author;
            meetAMemberDB.PictureURL = MeetAMember.PictureURL;
            meetAMemberDB.Para1 = MeetAMember.Para1;
            meetAMemberDB.Para2 = MeetAMember.Para2;
            meetAMemberDB.Para3 = MeetAMember.Para3;
            meetAMemberDB.Para4 = MeetAMember.Para4;
            meetAMemberDB.Para5 = MeetAMember.Para5;
            meetAMemberDB.Para6 = MeetAMember.Para6;
            meetAMemberDB.Para7 = MeetAMember.Para7;
            meetAMemberDB.Para8 = MeetAMember.Para8;
            meetAMemberDB.Para9 = MeetAMember.Para9;
            meetAMemberDB.Para10 = MeetAMember.Para10;
            await _db.SaveChangesAsync();

            return RedirectToPage("Index"); 
        }
    }
}
