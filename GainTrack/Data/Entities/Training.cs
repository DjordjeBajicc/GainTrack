using System;
using System.Collections.Generic;

namespace GainTrack.Data.Entities;

public partial class Training
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int UserId { get; set; }

    public sbyte Deleted { get; set; }

    public virtual ICollection<TrainingHasExercise> TrainingHasExercises { get; set; } = new List<TrainingHasExercise>();

    public virtual User User { get; set; } = null!;
}
