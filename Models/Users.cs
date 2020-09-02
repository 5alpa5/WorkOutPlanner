using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Users
    {
        public Users()
        {
            Plan = new HashSet<Plan>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Plan> Plan { get; set; }
    }
}
