using System;
using System.Collections.Generic;

namespace GainTrack.Data.Entities;

public partial class Exercise
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Details { get; set; }

    public sbyte Deleted { get; set; }

    public virtual CardioExercise? CardioExercise { get; set; }

    public virtual ICollection<TrainingHasExercise> TrainingHasExercises { get; set; } = new List<TrainingHasExercise>();

    public virtual WeightExercise? WeightExercise { get; set; }
}
