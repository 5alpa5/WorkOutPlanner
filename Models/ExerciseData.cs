using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class ExerciseData
    {
        public int IdexerciseDataId { get; set; }
        public int? ExerciseId { get; set; }
        public string ExerciseData1 { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}
