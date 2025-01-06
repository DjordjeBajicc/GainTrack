using GainTrack.Data.Entities;
using GainTrack.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public TrainingsViewModel(IServiceProvider serviceProvider, User trainee)
        {
            _traningService = serviceProvider.GetRequiredService<ITraningService>();
            _trainingHasExerciseService = serviceProvider.GetRequiredService<ITrainingHasExerciseService>();
            _userService = serviceProvider.GetRequiredService<IUserService>();
            _concreteExerciseOnTrainingService = serviceProvider.GetRequiredService<IConcreteExerciseOnTrainingService>();
            _serieService = serviceProvider.GetRequiredService<ISerieService>();
            Trainee = trainee;

            Trainings = new ObservableCollection<Training>();
            ExercisesWithSeries = new ObservableCollection<ConcreteExerciseOnTraining>();
            SeriesForDataGrid = new ObservableCollection<Serie>();
            loadTrainigNamesAndDates();
        }

        public async void loadTrainigNamesAndDates()
        {
            Trainings.Clear();
            ExercisesWithSeries.Clear();
            var trainings = await _traningService.GetAllTrainingsIncludeDeletedAsync(Trainee.Id);
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
                var concretes = await _concreteExerciseOnTrainingService.GetConcreteExercisesOnTrainingsByTrainingHasExerciseIdAsync(trainingHasExercise.Id);
                //MessageBox.Show(concretes.Count() + "");
                foreach (var concrete in concretes)
                {
                    concrete.TrainingHasExercise = trainingHasExercise;
                    if (!ExercisesWithSeries.Contains(concrete))
                    {
                        ExercisesWithSeries.Add(concrete);
                    }
                }
            }
        }

        private async void loadSeries()
        {
            if (SelectedTraining != null)
            {
                SeriesForDataGrid.Clear();

                var series = await _serieService.GetSerieByConcreteExerciseOnTrainingTrainingHasExerciseIdAndDateAsync(SelectedTraining.TrainingHasExerciseId, SelectedTraining.Date);

                foreach (Serie serie in series)
                {
                    serie.ConcreteExerciseOnTraining = SelectedTraining;
                    SeriesForDataGrid.Add(serie);
                }
            }
        }
    }
}
