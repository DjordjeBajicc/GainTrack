using System;
using System.Collections.Generic;

namespace GainTrack.Data.Entities;

public class Trainer
{
    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public virtual ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();
}
