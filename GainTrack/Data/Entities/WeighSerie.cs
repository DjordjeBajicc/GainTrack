using System;
using System.Collections.Generic;

namespace GainTrack.Data.Entities;

public partial class WeighSerie
{
    public decimal? Weight { get; set; }

    public int? Reps { get; set; }

    public int SerieSerialNumber { get; set; }

    public DateOnly SerieConcreteExerciseOnTrainingDate { get; set; }

    public int SerieConcreteExerciseOnTrainingTrainingHasExerciseId { get; set; }

    public virtual Serie Serie { get; set; } = null!;
}
