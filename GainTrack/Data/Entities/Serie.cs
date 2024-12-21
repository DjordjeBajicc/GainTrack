using GainTrack.Data.Entities;
using System.ComponentModel;

public partial class Serie : INotifyPropertyChanged
{
    private int _serialNumber;
    private DateOnly _concreteExerciseOnTrainingDate;
    private int _concreteExerciseOnTrainingTrainingHasExerciseId;
    private decimal? _weight;
    private int? _reps;
    private TimeOnly? _time;
    private decimal? _distance;  // Nova promenljiva

    public int SerialNumber
    {
        get => _serialNumber;
        set
        {
            if (_serialNumber != value)
            {
                _serialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }
    }

    public DateOnly ConcreteExerciseOnTrainingDate
    {
        get => _concreteExerciseOnTrainingDate;
        set
        {
            if (_concreteExerciseOnTrainingDate != value)
            {
                _concreteExerciseOnTrainingDate = value;
                OnPropertyChanged(nameof(ConcreteExerciseOnTrainingDate));
            }
        }
    }

    public int ConcreteExerciseOnTrainingTrainingHasExerciseId
    {
        get => _concreteExerciseOnTrainingTrainingHasExerciseId;
        set
        {
            if (_concreteExerciseOnTrainingTrainingHasExerciseId != value)
            {
                _concreteExerciseOnTrainingTrainingHasExerciseId = value;
                OnPropertyChanged(nameof(ConcreteExerciseOnTrainingTrainingHasExerciseId));
            }
        }
    }

    public decimal? Weight
    {
        get => _weight;
        set
        {
            if (_weight != value)
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
    }

    public int? Reps
    {
        get => _reps;
        set
        {
            if (_reps != value)
            {
                _reps = value;
                OnPropertyChanged(nameof(Reps));
            }
        }
    }

    public TimeOnly? Time
    {
        get => _time;
        set
        {
            if (_time != value)
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
    }

    public decimal? Distance  // Nova svojina
    {
        get => _distance;
        set
        {
            if (_distance != value)
            {
                _distance = value;
                OnPropertyChanged(nameof(Distance));
            }
        }
    }

    public virtual ConcreteExerciseOnTraining ConcreteExerciseOnTraining { get; set; } = null!;

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
