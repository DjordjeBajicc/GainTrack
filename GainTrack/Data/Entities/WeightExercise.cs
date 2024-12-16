using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GainTrack.Data.Entities;

public partial class WeightExercise
{
    [Column("Exercise_Id")]
    public int ExerciseId { get; set; }

    public virtual Exercise Exercise { get; set; } = null!;
}
