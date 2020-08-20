using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models.ViewModel
{
    public class QuestionChoicesVM
    {
        public IList<Choices> Choices { get; set; }
        public IList<Questions> Questions { get; set; }
    }
}
