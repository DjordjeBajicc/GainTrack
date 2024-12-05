using System;
using System.Collections.Generic;

namespace GainTrack.Data.Entities;

public partial class ConcreteExerciseOnTraining
{
    public DateOnly Date { get; set; }

    public int TrainingHasExerciseId { get; set; }

    public virtual ICollection<Serie> Series { get; set; } = new List<Serie>();

    public virtual TrainingHasExercise TrainingHasExercise { get; set; } = null!;
}
