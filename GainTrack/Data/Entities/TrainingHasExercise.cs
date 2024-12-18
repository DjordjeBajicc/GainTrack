using GainTrack.Data.Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class TrainingHasExercise : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public int TrainingId { get; set; }
    public int ExerciseId { get; set; }

    public sbyte Deleted { get; set; }

    private int _numberOfSeries;
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
