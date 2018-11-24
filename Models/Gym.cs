using System;
using System.Collections.Generic;

namespace GymApp.Models
{
    public partial class Gym
    {
        public Gym()
        {
            Membership = new HashSet<Membership>();
        }

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public User Owner { get; set; }
        public ICollection<Membership> Membership { get; set; }
    }
}
