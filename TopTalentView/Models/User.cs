using System;
using System.Collections.Generic;

#nullable disable

namespace TopTalentView.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public int? UserPhone { get; set; }
        public string UserAddress { get; set; }
        public string UserDescription { get; set; }
        public int UserStatus { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
