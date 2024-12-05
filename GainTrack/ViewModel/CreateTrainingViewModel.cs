using GainTrack.Data.Entities;
using GainTrack.Services;
using GainTrack.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GainTrack.ViewModel
{
    public class CreateTrainingViewModel : INotifyPropertyChanged
    {
        private readonly IExerciseService _exerciseService;
        private readonly ITraningService _TraningService;
        private readonly IWeigthExerciseService _WeigthExerciseService;
        private readonly ICardioExerciseService _CardioExerciseService;
        private readonly ITrainingHasExerciseService _TrainingHasExerciseService;

        private User _selectedUser;



        // Properties for binding
        private string _trainingName;
        public string TrainingName
        {
            get => _trainingName;
            set
            {
                _trainingName = value;
                OnPropertyChanged(nameof(TrainingName));
            }
        }

        private string _trainingDescription;
        public string TrainingDescription
        {
            get => _trainingDescription;
            set
            {
                _trainingDescription = value;
                OnPropertyChanged(nameof(TrainingDescription));
            }
        }

        private ObservableCollection<Exercise> _exercises;
        public ObservableCollection<Exercise> Exercises
        {
            get => _exercises;
            set
            {
                _exercises = value;
                OnPropertyChanged(nameof(Exercises));
            }
        }

        private ObservableCollection<Exercise> _filteredExercises;
        public ObservableCollection<Exercise> FilteredExercises
        {
            get => _filteredExercises;
            set
            {
                _filteredExercises = value;
                OnPropertyChanged(nameof(FilteredExercises));
            }
        }

        private Exercise _selectedExercise;
        public Exercise SelectedExercise
        {
            get => _selectedExercise;
            set
            {
                _selectedExercise = value;
                OnPropertyChanged(nameof(SelectedExercise));
            }
        }

        private ObservableCollection<TrainingHasExercise> _selectedExercises;
        public ObservableCollection<TrainingHasExercise> SelectedExercises
        {
            get => _selectedExercises;
            set
            {
                _selectedExercises = value;
                OnPropertyChanged(nameof(SelectedExercises));
            }
        }

        private string _selectedExerciseType;
        public string SelectedExerciseType
        {
            get => _selectedExerciseType;
            set
            {
                _selectedExerciseType = value;
                OnPropertyChanged(nameof(SelectedExerciseType));
                FilterExercises();
            }
        }

        public string SeriesCount { get; set; }

        // Commands
        public ICommand SaveTrainingCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand AddExerciseCommand { get; }
        public ICommand CreateNewExerciseCommand { get; }

        // Constructor
        public CreateTrainingViewModel(IExerciseService exerciseService, ITraningService traningService,  User user, IWeigthExerciseService weigthExerciseService, ICardioExerciseService cardioExerciseService, ITrainingHasExerciseService trainingHasExerciseService)
        {
            _exerciseService = exerciseService;
            _TraningService = traningService;
            _CardioExerciseService = cardioExerciseService;
            _WeigthExerciseService = weigthExerciseService;
            _TrainingHasExerciseService = trainingHasExerciseService;

            Exercises = new ObservableCollection<Exercise>();
            FilteredExercises = new ObservableCollection<Exercise>();
            SelectedExercises = new ObservableCollection<TrainingHasExercise>();

            // Initialize commands
            SaveTrainingCommand = new RelayCommand(SaveTraining);
            CancelCommand = new RelayCommand(Cancel);
            AddExerciseCommand = new RelayCommand(AddExercise);
            CreateNewExerciseCommand = new RelayCommand(CreateNewExercise);

            // Load exercises from the database
            LoadExercisesAsync();
            _selectedUser = user;
            _WeigthExerciseService = weigthExerciseService;
            _CardioExerciseService = cardioExerciseService;
            _TrainingHasExerciseService = trainingHasExerciseService;
        }

        private async Task LoadExercisesAsync()
        {
            var exercisesFromDb = await _exerciseService.GetAllExercisesAsync();
            Exercises = new ObservableCollection<Exercise>(exercisesFromDb);
            FilterExercises(); // Initial filtering based on default type
        }

        private async void FilterExercises()
        {
            if (string.IsNullOrEmpty(SelectedExerciseType))
            {
                FilteredExercises = new ObservableCollection<Exercise>(Exercises);
            }
            else
            {
                var WeightExercises = await _WeigthExerciseService.GetAllWeightExercisesAsync();
                ObservableCollection<WeightExercise> _weightExercises = new ObservableCollection<WeightExercise>(WeightExercises);

                var CardioExercise = await _CardioExerciseService.GetAllCardioExercisesAsync();
                ObservableCollection<CardioExercise> _cardioExercise = new ObservableCollection<CardioExercise>(CardioExercise);

                foreach(Exercise exercise in Exercises)
                {
                    if(SelectedExerciseType.Equals("Težinske"))
                    {
                        bool flagForWeight = false;
                        foreach (WeightExercise weight in _weightExercises)
                        {
                            if (weight.ExerciseId.Equals(exercise.Id))
                            {
                                flagForWeight = true;
                                break;
                            }
                        }
                        if (flagForWeight)
                            FilteredExercises.Add(exercise);
                    }
                    else if(SelectedExerciseType.Equals("Kardio"))
                    {
                        bool flagForCardio = false;
                        foreach (CardioExercise cardio in _cardioExercise)
                        {
                            if (cardio.ExerciseId.Equals(exercise.Id))
                            {
                                flagForCardio = true;
                                break;
                            }
                        }
                        if (flagForCardio)
                            FilteredExercises.Add(exercise);
                    }
                }
               
            }
        }

        private void AddExercise()
        {
            if (SelectedExercise != null && int.TryParse(SeriesCount, out int series))
            {
                var exerciseWithSeries = new TrainingHasExercise
                {
                    ExerciseId = SelectedExercise.Id,
                    NumberOfSeries = series
                };

                SelectedExercises.Add(exerciseWithSeries);
            }
        }

        private async void SaveTraining()
        {
            var training = new Training
            {
                Name = TrainingName,
                UserId = _selectedUser.Id // Poveži trening sa korisnikom
            };

            // Pozovi servis za čuvanje treninga u bazi
            await _TraningService.AddTrainingAsync(training);

            // Dodaj sve odabrane vežbe (TrainingHasExercise) za ovaj trening
            foreach (var selectedExercise in SelectedExercises)
            {
                selectedExercise.TrainingId = training.Id; // Poveži TrainingHasExercise sa treningom
                await _TrainingHasExerciseService.AddTrainignHasExerciseAsync(selectedExercise);
            }

            // Nakon što je trening sa vežbama sačuvan, možeš da očistiš selektovane vežbe
            SelectedExercises.Clear();

            // Opcionalno, možeš da obavestiš korisnika o uspehu ili grešci
            MessageBox.Show("Trening je uspešno sačuvan!");
        }

        private void Cancel()
        {
            
        }

        private void CreateNewExercise()
        {
            // Logika za otvaranje prozora za kreiranje nove vežbe
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
