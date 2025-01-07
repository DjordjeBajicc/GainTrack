using GainTrack.Data.Entities;
using GainTrack.Services;
using GainTrack.View.CustomView;
using LiveCharts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GainTrack.ViewModel
{
    public class ExerciseProgressViewModel : BaseViewModel
    {
        private IExerciseService _exerciseService;
        private IWeigthExerciseService _weigthExerciseService;
        private ICardioExerciseService _cardioExerciseService;
        private readonly IServiceProvider _serviceProvider;
        private ISerieService _serieService;
        private ObservableCollection<Exercise> _exercises;
        private User Trainee;

        public ObservableCollection<Exercise> Exercises
        {
            get => _exercises;
            set => SetProperty(ref _exercises, value);
        }

        private Exercise _selectedExercise;

        public Exercise SelectedExercise
        {
            get => _selectedExercise;
            set
            {
                SetProperty(ref _selectedExercise, value);
                LoadSeriesForSelectedExercise();
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

        private ObservableCollection<Serie> _loadedSeries;

        public ObservableCollection<Serie> LoadedSeries
        {
            get => _loadedSeries;
            set => SetProperty(ref _loadedSeries, value);
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


        public ExerciseProgressViewModel(IServiceProvider serviceProvider, User trainee)
        {
            _serviceProvider = serviceProvider;
            Trainee = trainee;
            _exerciseService = serviceProvider.GetRequiredService<IExerciseService>();
            _weigthExerciseService = serviceProvider.GetRequiredService<IWeigthExerciseService>();
            _cardioExerciseService = serviceProvider.GetRequiredService<ICardioExerciseService>();
            _serieService = serviceProvider.GetRequiredService<ISerieService>();
            FilteredExercises = new ObservableCollection<Exercise>();
            LoadedSeries = new ObservableCollection<Serie>();
            FilterExercises();
            
        }

        public async Task LoadExercisesAsync()
        {
            var exercisesFromDb = await _exerciseService.GetAllExercisesAsync();
            Exercises = new ObservableCollection<Exercise>(exercisesFromDb);
        }

        public async void FilterExercises()
        {
            FilteredExercises.Clear();
            await LoadExercisesAsync();
            if (SelectedExerciseType == null)
                SelectedExerciseType = "Weight";
            if (SelectedExerciseType.Equals("Weight"))
            {
                var weightExercises = await _weigthExerciseService.GetAllWeightExercisesAsync();
                var filteredWeightExercises = Exercises.Where(e => weightExercises.Any(w => w.ExerciseId == e.Id)).ToList();
                
                foreach(var e in filteredWeightExercises)
                {
                    FilteredExercises.Add(e);
                }
                //MessageBox.Show(FilteredExercises.Count() + "");
            }
            else if (SelectedExerciseType.Equals("Cardio"))
            {
                var cardioExercises = await _cardioExerciseService.GetAllCardioExercisesAsync();
                var filteredCardioExercises = Exercises.Where(e => cardioExercises.Any(c => c.ExerciseId == e.Id)).ToList();
                
                foreach (var e in filteredCardioExercises)
                {
                    FilteredExercises.Add(e);
                }
            }
        }

        private async void LoadSeriesForSelectedExercise()
        {
            if(SelectedExercise != null)
            {
                LoadedSeries.Clear();

                var series = await _serieService.GetSeriesByTraineeAndExerciseAsync(Trainee.Id, SelectedExercise.Id);
                foreach(var s in series)
                {
                    LoadedSeries.Add(s);
                }
                CustomMessageBox.Show(LoadedSeries.Count() + "");
            }
        }
    }
}
