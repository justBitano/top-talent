using System;
using System.Collections.Generic;

#nullable disable

namespace TopTalentView.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int BookingId { get; set; }
        public DateTime CreateDate { get; set; }
        public int BookingStatus { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int TalentId { get; set; }

        public virtual Talent Talent { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
