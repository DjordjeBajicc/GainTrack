using System;
using System.Collections.Generic;

namespace GainTrack.Data.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int? Trainer { get; set; }

    public sbyte Deleted { get; set; }

    public virtual ICollection<User> InverseTrainerNavigation { get; set; } = new List<User>();

    public virtual User? TrainerNavigation { get; set; }

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();

    public virtual ICollection<UserHasMessurement> UserHasMessurements { get; set; } = new List<UserHasMessurement>();

    public string FullName => $"{Firstname} {Lastname}";

}
