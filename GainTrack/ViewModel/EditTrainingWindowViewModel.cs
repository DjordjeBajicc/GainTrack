using GainTrack.Data.Entities;
using GainTrack.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GainTrack.ViewModel
{
    public class EditTrainingWindowViewModel : BaseViewModel
    {
        public int ChoosenTrainingId { get; set; }
        private IExerciseService _exerciseService;
        private ITrainingHasExerciseService _trainingHasExerciseService;
        private ITraningService _trainingService;
        private IWeigthExerciseService _weigthExerciseService;
        private ICardioExerciseService _cardioExerciseService;
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

        private string _exerciseName;

        public string ExerciseName
        {
            get => _exerciseName;
            set
            {
                _exerciseName = value;
                OnPropertyChanged(nameof(ExerciseName));
            }
        }

        private string _exerciseDescription;

        public string ExerciseDescription
        {
            get => _exerciseDescription;
            set
            {
                _exerciseDescription = value;
                OnPropertyChanged(nameof(ExerciseDescription));
            }
        }

        private ObservableCollection<TrainingHasExercise> _exercisesOnTraining;
        public ObservableCollection<TrainingHasExercise> ExercisesOnTraining
        {
            get => _exercisesOnTraining;
            set
            {
                _exercisesOnTraining = value;
                OnPropertyChanged(nameof(ExercisesOnTraining));
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

        private string _selectedExerciseType = "All";
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

        public ICommand AddExerciseCommand { get; }
        public ICommand RemoveExerciseCommand { get; }
        public ICommand CreateExerciseCommand { get; }
        public ICommand SaveCommand { get; }

        public EditTrainingWindowViewModel(ITrainingHasExerciseService trainingHasExerciseService, IExerciseService exerciseService, ITraningService traningService, IWeigthExerciseService weigthExerciseService, ICardioExerciseService cardioExerciseService, int trainingId)
        {
            _exerciseService = exerciseService;
            _trainingHasExerciseService = trainingHasExerciseService;
            _trainingService = traningService;
            _weigthExerciseService = weigthExerciseService;
            _cardioExerciseService = cardioExerciseService;
            ChoosenTrainingId = trainingId;
            AddExerciseCommand = new RelayCommand(AddExercise);
            SaveCommand = new RelayCommand(SaveChanges);
            FilteredExercises = new ObservableCollection<Exercise>();
            ExercisesOnTraining = new ObservableCollection<TrainingHasExercise>();
            Exercises = new ObservableCollection<Exercise>();
        }

        public async Task LoadExercisesForTraining()
        {
            var loadedExercisesForTraining = await _trainingHasExerciseService.GetTrainingHasExerciseByTrainingIdAsync(ChoosenTrainingId);
            ExercisesOnTraining = new ObservableCollection<TrainingHasExercise>(loadedExercisesForTraining);
            
        }

        public async Task LoadExercises()
        {
            var ex = await _exerciseService.GetAllExercisesAsync();
            Exercises = new ObservableCollection<Exercise>(ex);
        }
        private bool _isFiltering = false;

        private async void FilterExercises()
        {
            if (_isFiltering) return;
            //LoadExercises();
            try
            {
                _isFiltering = true;
                FilteredExercises = new ObservableCollection<Exercise>();

                if (string.IsNullOrEmpty(SelectedExerciseType) || SelectedExerciseType.Equals("All"))
                {
                    FilteredExercises = new ObservableCollection<Exercise>(Exercises);
                }
                else if (SelectedExerciseType.Equals("Weight"))
                {
                    var weightExercises = await _weigthExerciseService.GetAllWeightExercisesAsync();
                    var filteredWeightExercises = Exercises.Where(e => weightExercises.Any(w => w.ExerciseId == e.Id)).ToList();
                    FilteredExercises = new ObservableCollection<Exercise>(filteredWeightExercises);
                }
                else if (SelectedExerciseType.Equals("Cardio"))
                {
                    var cardioExercises = await _cardioExerciseService.GetAllCardioExercisesAsync();
                    var filteredCardioExercises = Exercises.Where(e => cardioExercises.Any(c => c.ExerciseId == e.Id)).ToList();
                    FilteredExercises = new ObservableCollection<Exercise>(filteredCardioExercises);
                }
                //MessageBox.Show($"FilteredExercises count: {FilteredExercises.Count}");
            }
            finally
            {
                _isFiltering = false;
            }
        }



        private async void AddExercise(object? obj)
        {
            if (_selectedExercise != null && _seriesCount > 0)
            {
                bool flag = true;
                foreach (TrainingHasExercise exercise in ExercisesOnTraining)
                {
                    if (exercise.ExerciseId == _selectedExercise.Id)
                    {
                        exercise.NumberOfSeries += _seriesCount;
                        flag = false;
                    }
                }

                if (flag)
                {

                    TrainingHasExercise trainingHasExercise = new TrainingHasExercise
                    {
                        ExerciseId = _selectedExercise.Id,
                        NumberOfSeries = _seriesCount,
                        TrainingId = ChoosenTrainingId
                    };

                    ExercisesOnTraining.Add(trainingHasExercise);
                    //await _trainingHasExerciseService.AddTrainignHasExerciseAsync(trainingHasExercise);
                    //ExercisesOnTraining.Clear();
                    //LoadExercisesForTraining();
                }
            }
            else
            {
                MessageBox.Show("Izaberite vjezbu i odaberite broj serija");
            }
        }

        private async void SaveChanges(object? obj)
        {
            var existingExercises = await  _trainingHasExerciseService.GetTrainingHasExerciseByTrainingIdAsync(ChoosenTrainingId);
            ObservableCollection<TrainingHasExercise> existingExercisesList = new ObservableCollection<TrainingHasExercise>(existingExercises);
            var newExercises = ExercisesOnTraining
                .Where(newEx => !existingExercises.Any(existingEx => existingEx.ExerciseId == newEx.ExerciseId))
                .ToList();
            ObservableCollection<TrainingHasExercise> newExercisesList = new ObservableCollection<TrainingHasExercise>(newExercises);

            foreach(var exercise in newExercisesList)
            {
                await _trainingHasExerciseService.AddTrainignHasExerciseAsync(exercise);
            }

            LoadExercisesForTraining();

        }


    }
}
