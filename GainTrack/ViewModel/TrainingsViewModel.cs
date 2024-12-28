using GainTrack.Data.Entities;
using GainTrack.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GainTrack.ViewModel
{
    public class TrainingsViewModel : BaseViewModel
    {

        private readonly ITraningService _traningService;
        private readonly IUserService _userService;
        private readonly ITrainingHasExerciseService _trainingHasExerciseService;
        private readonly IConcreteExerciseOnTrainingService _concreteExerciseOnTrainingService;
        private readonly ISerieService _serieService;

        public User Trainee { get; set; }
        private ObservableCollection<Serie> _seriesForDataGrid;

        public ObservableCollection<Serie> SeriesForDataGrid
        {
            get => _seriesForDataGrid;
            set
            {
                _seriesForDataGrid = value;
                OnPropertyChanged(nameof(SeriesForDataGrid));
            }
        }

        private ConcreteExerciseOnTraining _selectedTraining;

        public ConcreteExerciseOnTraining SelectedTraining
        {
            get => _selectedTraining;
            set
            {
                _selectedTraining = value;
                OnPropertyChanged(nameof(SelectedTraining));

                loadSeries();


            }
        }

        private ObservableCollection<ConcreteExerciseOnTraining> _exercisesWithSeries;

        public ObservableCollection<ConcreteExerciseOnTraining> ExercisesWithSeries
        {
            get => _exercisesWithSeries;
            set
            {
                _exercisesWithSeries = value;
                OnPropertyChanged(nameof(ExercisesWithSeries));
            }
        }

        private ObservableCollection<Training> _trainings;

        public ObservableCollection<Training> Trainings
        {
            get => _trainings;
            set
            {
                _trainings = value;
                OnPropertyChanged(nameof(Trainings));
            }
        }

        public TrainingsViewModel(ITraningService traningService, ISerieService serieService, IUserService userService, IConcreteExerciseOnTrainingService concreteExerciseOnTrainingService, ITrainingHasExerciseService trainingHasExerciseService, IServiceProvider serviceProvider)
        {
            _traningService = traningService;
            _trainingHasExerciseService = trainingHasExerciseService;
            _userService = userService;
            _concreteExerciseOnTrainingService = concreteExerciseOnTrainingService;
            _serieService = serieService;

            Trainings = new ObservableCollection<Training>();
            ExercisesWithSeries = new ObservableCollection<ConcreteExerciseOnTraining>();
            SeriesForDataGrid = new ObservableCollection<Serie>();
        }

        public async void loadTrainigNamesAndDates()
        {
            Trainings.Clear();
            var trainings = await _traningService.GetTrainingsForUserAsync(Trainee.Id);
            foreach (var training in trainings)
            {
                Trainings.Add(training);
            }
            ObservableCollection<TrainingHasExercise> trainingHasExercises = new ObservableCollection<TrainingHasExercise>();
            foreach(Training t in Trainings)
            {
                var trainigHasExercisesForTraining = await _trainingHasExerciseService.GetTrainingHasExerciseByTrainingIdAsync(t.Id);
                foreach(TrainingHasExercise the in trainigHasExercisesForTraining)
                {
                    the.Training = t;
                    trainingHasExercises.Add(the);
                }
            }

            foreach(TrainingHasExercise trainingHasExercise in trainingHasExercises)
            {
                ConcreteExerciseOnTraining concrete = await _concreteExerciseOnTrainingService.GetConcreteExerciseOnTrainingByTrainingHasExerciseIdAsync(trainingHasExercise.Id);
                concrete.TrainingHasExercise = trainingHasExercise;
                bool flag = true;
                if(concrete != null)
                {
                    foreach(ConcreteExerciseOnTraining c in ExercisesWithSeries)
                    {
                        if (c.Date.Equals(concrete.Date) && c.TrainingHasExercise.Training.Name.Equals(concrete.TrainingHasExercise.Training.Name))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        ExercisesWithSeries.Add(concrete);
                    }
                    
                }
            }
        }

        private async void loadSeries()
        {
            SeriesForDataGrid.Clear();
            var trainigHasExercisesForTraining = await _trainingHasExerciseService.GetTrainingHasExerciseByTrainingIdAsync(SelectedTraining.TrainingHasExercise.Training.Id);
            ObservableCollection<TrainingHasExercise> trainingHasExercises = new ObservableCollection<TrainingHasExercise>(trainigHasExercisesForTraining);
            foreach(TrainingHasExercise the in trainingHasExercises)
            {
                the.Training = SelectedTraining.TrainingHasExercise.Training;
                ConcreteExerciseOnTraining concrete = await _concreteExerciseOnTrainingService.GetConcreteExerciseOnTrainingByTrainingHasExerciseIdAsync(the.Id);
                concrete.TrainingHasExercise = the;
                var series = await _serieService.GetSerieByConcreteExerciseOnTrainingTrainingHasExerciseIdAndDateAsync(concrete.TrainingHasExerciseId, concrete.Date);
                
                foreach(Serie serie in series)
                {
                    serie.ConcreteExerciseOnTraining = concrete;
                    SeriesForDataGrid.Add(serie);
                }
            }
        }
    }
}
