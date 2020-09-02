using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Exercise
    {
        public Exercise()
        {
            ExerciseData = new HashSet<ExerciseData>();
        }

        public int ExerciseId { get; set; }
        public int? PlanId { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDesc { get; set; }

        public virtual Plan Plan { get; set; }
        public virtual ICollection<ExerciseData> ExerciseData { get; set; }
    }
}
