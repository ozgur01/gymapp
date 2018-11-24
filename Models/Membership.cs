using System;
using System.Collections.Generic;

namespace GymApp.Models
{
    public partial class Membership
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GymId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Gym Gym { get; set; }
        public User User { get; set; }
    }
}
