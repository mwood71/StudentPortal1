using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VolunteerEventID { get; set; }
        [ForeignKey("VolunteerEventID")]
        public virtual VolunteerEvent VolunteerEvent { get; set; }
    }
}
