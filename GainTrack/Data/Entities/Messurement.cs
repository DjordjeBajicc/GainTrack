using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GainTrack.Data.Entities;

public partial class Messurement
{
    [Key]
    public string Name { get; set; } = null!;

    public decimal Meassure { get; set; }

    public virtual ICollection<UserHasMessurement> UserHasMessurements { get; set; } = new List<UserHasMessurement>();
}
