using System;
using System.Collections.Generic;

namespace GainTrack.Data.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Username { get; set; }

    public string Password { get; set; }

    public string Theme { get; set; }
    public string Language { get; set; }

    public sbyte Deleted { get; set; }

    public Trainee Trainee { get; set; }
    public Trainer Trainer { get; set; }

    public string FullName => $"{Firstname} {Lastname} ({Username})";
}
