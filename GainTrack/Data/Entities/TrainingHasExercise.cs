using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace GainTrack.Data.Entities;

public partial class TrainingHasExercise : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    [Column("Training_Id")]
    public int TrainingId { get; set; }

    [Column("Exercise_Id")]
    public int ExerciseId { get; set; }

    public sbyte Deleted { get; set; }


    private int _numberOfSeries;
    [Column("Number_Of_Series")]
    public int NumberOfSeries
    {
        get => _numberOfSeries;
        set
        {
            if (_numberOfSeries != value)
            {
                _numberOfSeries = value;
                OnPropertyChanged();
            }
        }
    }

    public int Id { get; set; }

    public virtual ICollection<ConcreteExerciseOnTraining> ConcreteExerciseOnTrainings { get; set; } = new List<ConcreteExerciseOnTraining>();

    public virtual Exercise Exercise { get; set; } = null!;

    public virtual Training Training { get; set; } = null!;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
