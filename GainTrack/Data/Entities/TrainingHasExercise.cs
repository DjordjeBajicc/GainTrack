using System;
using System.Collections.Generic;

namespace GainTrack.Data.Entities;

public partial class TrainingHasExercise
{
    public int TrainingId { get; set; }

    public int ExerciseId { get; set; }

    public int NumberOfSeries { get; set; }

    public int Id { get; set; }

    public virtual ICollection<ConcreteExerciseOnTraining> ConcreteExerciseOnTrainings { get; set; } = new List<ConcreteExerciseOnTraining>();

    public virtual Exercise Exercise { get; set; } = null!;

    public virtual Training Training { get; set; } = null!;
}
