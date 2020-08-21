using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models.ViewModel
{
    public class VolunteerVM
    {
        public IList<Volunteer> VolunteerList { get; set; }
        public VolunteerEvent VolunteerEvent { get; set; }
    }
}
