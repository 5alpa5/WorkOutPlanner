using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Plan
    {
        public Plan()
        {
            Exercise = new HashSet<Exercise>();
        }

        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public string PlanDesc { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Exercise> Exercise { get; set; }
    }
}
