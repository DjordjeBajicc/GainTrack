using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GainTrack.Data.Entities;

public partial class Training
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Column("Trainee_Id")]
    public int TraineeId { get; set; }

    public sbyte Deleted { get; set; }

    public virtual ICollection<TrainingHasExercise> TrainingHasExercises { get; set; } = new List<TrainingHasExercise>();

    
    public virtual Trainee Trainee { get; set; } = null!;
}
