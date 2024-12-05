using System;
using System.Collections.Generic;

namespace GainTrack.Data.Entities;

public partial class CardioSerie
{
    public TimeOnly? Time { get; set; }

    public int SerieSerialNumber { get; set; }

    public DateOnly SerieConcreteExerciseOnTrainingDate { get; set; }

    public int SerieConcreteExerciseOnTrainingTrainingHasExerciseId { get; set; }

    public virtual Serie Serie { get; set; } = null!;
}
