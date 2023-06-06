using System;
using System.Collections.Generic;

#nullable disable

namespace TopTalentView.Models
{
    public partial class BookingDetail
    {
        public int BookingDetailId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Cash { get; set; }
        public int BookingId { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
