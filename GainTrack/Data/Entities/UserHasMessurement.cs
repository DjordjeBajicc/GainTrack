using System;

namespace GainTrack.Data.Entities;

public class UserHasMessurement
{
    public int TraineeId { get; set; }

    public string MessurementName { get; set; } = null!;

    public decimal Value { get; set; }

    public DateOnly Date { get; set; }

    public virtual Trainee Trainee{ get; set; } = null!;

    public virtual Messurement Messurement { get; set; } = null!;
}
