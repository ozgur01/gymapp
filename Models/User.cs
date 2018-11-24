using System;
using System.Collections.Generic;

namespace GymApp.Models
{
    public partial class User
    {
        public User()
        {
            Gym = new HashSet<Gym>();
            Membership = new HashSet<Membership>();
        }

        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte IsConfirmed { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserType UserType { get; set; }
        public ICollection<Gym> Gym { get; set; }
        public ICollection<Membership> Membership { get; set; }
    }
}
