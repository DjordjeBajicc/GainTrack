using System;
using System.Collections.Generic;

namespace GainTrack.Data.Entities;

public partial class Serie
{
    public int SerialNumber { get; set; }

    public DateOnly ConcreteExerciseOnTrainingDate { get; set; }

    public int ConcreteExerciseOnTrainingTrainingHasExerciseId { get; set; }

    public virtual CardioSerie? CardioSerie { get; set; }

    public virtual ConcreteExerciseOnTraining ConcreteExerciseOnTraining { get; set; } = null!;

    public virtual WeighSerie? WeighSerie { get; set; }
}
