using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GainTrack.Data.Entities;

public partial class WeightExercise
{
   
    public int ExerciseId { get; set; }

    public virtual Exercise Exercise { get; set; } = null!;
}
