using System;
using System.Collections.Generic;

namespace GainTrack.Data.Entities;

public partial class UserHasMessurement
{
    public int UserId { get; set; }

    public string MessurementName { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual Messurement Messurement { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
