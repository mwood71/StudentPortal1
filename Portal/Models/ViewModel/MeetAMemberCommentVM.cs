using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models.ViewModel
{
    public class MeetAMemberCommentVM
    {
        public MeetAMember MeetAMember { get; set; }
        public IList<Comment> CommentList { get; set; }
    }
}
