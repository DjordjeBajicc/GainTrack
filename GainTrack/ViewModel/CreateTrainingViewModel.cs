using GainTrack.Data.Entities;
using GainTrack.Services;
using GainTrack.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public User SelectedUser { get; set; }

        public event EventHandler TrainingAdded;    

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

        private int _seriesCount;
        public int SeriesCount
        {
            get => _seriesCount;
            set
            {
                _seriesCount = value;
                OnPropertyChanged(nameof(SeriesCount));
            }
        }

        public ICommand SaveTrainingCommand { get; }
        public ICommand RemoveExerciseCommand { get; }
        public ICommand AddExerciseCommand { get; }
        public ICommand CreateNewExerciseCommand { get; }

        public CreateTrainingViewModel(IExerciseService exerciseService, ITraningService traningService, IWeigthExerciseService weigthExerciseService, ICardioExerciseService cardioExerciseService, ITrainingHasExerciseService trainingHasExerciseService)
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
            RemoveExerciseCommand = new RelayCommand(RemoveExercise);
            AddExerciseCommand = new RelayCommand(AddExercise);
            CreateNewExerciseCommand = new RelayCommand(CreateNewExercise);

            // Load exercises from the database
            LoadExercisesAsync();
            //_selectedUser = user;
            _WeigthExerciseService = weigthExerciseService;
            _CardioExerciseService = cardioExerciseService;
            _TrainingHasExerciseService = trainingHasExerciseService;
        }

        public async Task LoadExercisesAsync()
        {
            var exercisesFromDb = await _exerciseService.GetAllExercisesAsync();
            Exercises = new ObservableCollection<Exercise>(exercisesFromDb);
           
            //FilterExercises(); 
        }

        private async void FilterExercises()
        {
            FilteredExercises.Clear();
            await LoadExercisesAsync();
            //MessageBox.Show(Exercises.Count().ToString());
            if (string.IsNullOrEmpty(SelectedExerciseType) || SelectedExerciseType.Equals("All"))
            {
                
                FilteredExercises = new ObservableCollection<Exercise>(Exercises);
                //MessageBox.Show(FilteredExercises.Count().ToString());
            }
            else if (SelectedExerciseType.Equals("Weight"))
            {
                var weightExercises = await _WeigthExerciseService.GetAllWeightExercisesAsync();
                var filteredWeightExercises = Exercises.Where(e => weightExercises.Any(w => w.ExerciseId == e.Id)).ToList();
                FilteredExercises = new ObservableCollection<Exercise>(filteredWeightExercises);
                //MessageBox.Show(FilteredExercises.Count().ToString());
            }
            else if (SelectedExerciseType.Equals("Cardio"))
            {
                var cardioExercises = await _CardioExerciseService.GetAllCardioExercisesAsync();
                var filteredCardioExercises = Exercises.Where(e => cardioExercises.Any(c => c.ExerciseId == e.Id)).ToList();
                FilteredExercises = new ObservableCollection<Exercise>(filteredCardioExercises);
                //MessageBox.Show(FilteredExercises.Count().ToString());
            }
        }


        private async void AddExercise(object? obj)
        {
            if (SelectedExercise != null)
            {
                
                Exercise exercise = await _exerciseService.GetExerciseByIdAsync(SelectedExercise.Id);
                
                bool flag = true;
                foreach(TrainingHasExercise trainingHasExercise in SelectedExercises)
                {
                    if(trainingHasExercise.ExerciseId == exercise.Id)
                    {
                        
                        trainingHasExercise.NumberOfSeries += _seriesCount;
                        flag = false;
                        
                        break;
                    }
                }
                if (flag && _seriesCount > 0)
                {
                    //MessageBox.Show(SelectedExercise.Id.ToString());
                    TrainingHasExercise exerciseWithSeries = new TrainingHasExercise
                    {
                        ExerciseId = SelectedExercise.Id,
                        NumberOfSeries = _seriesCount,
                        Exercise = exercise
                    };
                    //MessageBox.Show(exerciseWithSeries.ExerciseId.ToString());
                    SelectedExercises.Add(exerciseWithSeries);
                }
            }
        }

        private async void SaveTraining(object? obj)
        {
            if(string.IsNullOrEmpty(_trainingName))
            {
                MessageBox.Show(App.Current.Resources["FillAllFields"].ToString());
            }
            else
            {
                Training training = new Training
                {
                    Name = _trainingName,
                    UserId = SelectedUser.Id
                };

                
                training = await _TraningService.AddTrainingAsync(training);

                
                foreach (var selectedExercise in SelectedExercises)
                {
                    //MessageBox.Show(selectedExercise.ExerciseId.ToString());
                    selectedExercise.TrainingId = training.Id; 
                    await _TrainingHasExerciseService.AddTrainingHasExerciseAsync(training.Id, selectedExercise.Exercise.Id, selectedExercise.NumberOfSeries);
                }

                // Nakon što je trening sa vežbama sačuvan, možeš da očistiš selektovane vežbe
                SelectedExercises.Clear();

                // Opcionalno, možeš da obavestiš korisnika o uspehu ili grešci
                MessageBox.Show(App.Current.Resources["TheTrainingWasSuccessfullySaved"].ToString());
                TrainingAdded?.Invoke(this, EventArgs.Empty);
            }
        }

        private void RemoveExercise(object? obj)
        {
            if(obj is int ExerciseId)
            {
                var exerciseToRemove = SelectedExercises.FirstOrDefault(e => e.ExerciseId == ExerciseId);
                if (exerciseToRemove != null)
                {
                    SelectedExercises.Remove(exerciseToRemove);
                }

            }
        }

        private void CreateNewExercise(object? obj)
        {
            CreateExerciseViewModel createExerciseViewModel = new CreateExerciseViewModel(_exerciseService, _WeigthExerciseService, _CardioExerciseService);
            CreateExercise createExercise = new CreateExercise(createExerciseViewModel);
            createExercise.Show();
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
