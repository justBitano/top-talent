using System;
using System.Collections.Generic;

#nullable disable

namespace TopTalentView.Models
{
    public partial class Talent
    {
        public Talent()
        {
            Bookings = new HashSet<Booking>();
        }

        public int TalentId { get; set; }
        public string TalentEmail { get; set; }
        public string TalentPassword { get; set; }
        public string TalentName { get; set; }
        public int? TalentPhone { get; set; }
        public string TalentAddress { get; set; }
        public string TalentDescription { get; set; }
        public int TalentStatus { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
