using System;
using System.Collections.Generic;

namespace GainTrack.Data.Entities;

public class Trainee
{
    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public int TrainerId { get; set; }

    public virtual Trainer Trainer { get; set; } = null!;

    public virtual ICollection<Training> Trainings { get; set; } = new List<Training>();

    public virtual ICollection<UserHasMessurement> UserHasMessurements { get; set; } = new List<UserHasMessurement>();
}
