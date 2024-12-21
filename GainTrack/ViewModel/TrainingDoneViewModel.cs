using GainTrack.Data.Entities;
using GainTrack.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GainTrack.ViewModel
{
    public class TrainingDoneViewModel : BaseViewModel
    {
        private readonly ITraningService _traningService;
        private readonly IUserService _userService;
        private readonly ITrainingHasExerciseService _trainingHasExerciseService;
        private readonly IConcreteExerciseOnTrainingService _concreteExerciseOnTrainingService;
        private readonly ISerieService _serieService;
        private readonly CreateTrainingViewModel _createTrainingViewModel;
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

        private DateOnly? _date;

        public DateOnly? Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
                
            }
        }


        private Training _selectedTraining;

        public Training SelectedTraining
        {
            get => _selectedTraining;
            set
            {
                _selectedTraining = value;
                OnPropertyChanged(nameof(SelectedTraining));
                
                loadExercisesForTraining();
                

            }
        }

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

        public ICommand SaveCommand { get; }
        public ICommand CreateTrainingCommand { get; }
        public ICommand DeleteTrainingCommand { get; }


        public TrainingDoneViewModel(ITraningService traningService, ISerieService serieService, IUserService userService, IConcreteExerciseOnTrainingService concreteExerciseOnTrainingService, ITrainingHasExerciseService trainingHasExerciseService, IServiceProvider serviceProvider)
        {
            _traningService = traningService;
            _trainingHasExerciseService = trainingHasExerciseService;
            _userService = userService;
            _concreteExerciseOnTrainingService = concreteExerciseOnTrainingService;
            _serieService = serieService;

            CreateTrainingCommand = new RelayCommand(createTraining);
            DeleteTrainingCommand = new RelayCommand(DeleteTraining);
            SaveCommand = new RelayCommand(Save);

            _createTrainingViewModel = serviceProvider.GetRequiredService<CreateTrainingViewModel>();
            Trainings = new ObservableCollection<Training>();
            ExercisesWithSeries = new ObservableCollection<ConcreteExerciseOnTraining>();
            SeriesForDataGrid = new ObservableCollection<Serie>();

            _createTrainingViewModel.TrainingAdded += OnTrainingAdded;

        }

        public async void loadTrainings()
        {
            Trainings.Clear();
            var trainings = await _traningService.GetTrainingsForUserAsync(int.Parse(ConfigurationManager.AppSettings["TrainerId"]));
            foreach (var training in trainings)
            {
                Trainings.Add(training);
            }
        }


        private async void createTraining(object? obj)
        {
            User user = await _userService.GetUserByIdAsync(int.Parse(ConfigurationManager.AppSettings["TrainerId"]));
            _createTrainingViewModel.SelectedUser = user;
            CreateTraining createTraining = new CreateTraining(_createTrainingViewModel);

            createTraining.Show();


        }

        private void OnTrainingAdded(object? sender, EventArgs e)
        {
            // Ponovo učitaj treninge
            loadTrainings();
        }

        private void DeleteTraining(object? obj)
        {

            if (obj is int id)
            {
                foreach (Training tr in Trainings)
                {
                    if (tr.Id == id)
                    {
                        _traningService.DeleteTrainingAsync(id);
                        loadTrainings();
                        break;
                    }
                }
            }
            

        }

        private async void loadExercisesForTraining()
        {
            if (SelectedTraining != null)
            {
                ExercisesWithSeries.Clear();
                var exercisesAndSeries = await _trainingHasExerciseService.GetTrainingHasExerciseByTrainingIdAsync(SelectedTraining.Id);
                ObservableCollection<TrainingHasExercise> trainingHasExercises = new ObservableCollection<TrainingHasExercise>(exercisesAndSeries);
                foreach (TrainingHasExercise te in trainingHasExercises)
                {
                    List<Serie> serieList = new List<Serie>();
                    for(int i = 1; i <= te.NumberOfSeries; i++)
                    {
                        serieList.Add(new Serie
                        {
                            SerialNumber = i,
                            ConcreteExerciseOnTrainingTrainingHasExerciseId = te.Id,
                            
                        });
                    }
                    ConcreteExerciseOnTraining concrete = new ConcreteExerciseOnTraining
                    {    
                        TrainingHasExerciseId = te.Id,
                        Series = serieList,
                        TrainingHasExercise = te

                    };
                    ExercisesWithSeries.Add(concrete);
                }
                PopulateSeriesForDataGrid();
            }
        }

        private void PopulateSeriesForDataGrid()
        {
            SeriesForDataGrid.Clear();

            foreach (var exercise in ExercisesWithSeries)
            {
                foreach (var serie in exercise.Series)
                {
                    // Dodajte seriju u kolekciju za prikaz u DataGrid-u
                    SeriesForDataGrid.Add(new Serie
                    {
                        
                        SerialNumber = serie.SerialNumber,
                        ConcreteExerciseOnTrainingTrainingHasExerciseId = serie.ConcreteExerciseOnTrainingTrainingHasExerciseId,
                        ConcreteExerciseOnTraining = exercise
                        // Dodajte dodatna polja koja želite prikazati
                    });
                }
            }
        }

       

        private async void Save(object? obj)
        {
            if (SelectedTraining != null && Date.HasValue)
            {
                bool flag = await checkAvailability();
                if (!flag)
                {
                    
                    return;
                }

                foreach (ConcreteExerciseOnTraining concreteExerciseOnTraining in ExercisesWithSeries)
                {
                    concreteExerciseOnTraining.Date = Date.Value;
                    concreteExerciseOnTraining.TrainingHasExercise = null;
                    concreteExerciseOnTraining.Series.Clear();
                    //MessageBox.Show(concreteExerciseOnTraining.TrainingHasExerciseId + "  " + concreteExerciseOnTraining.Date);
                    await _concreteExerciseOnTrainingService.AddConcreteExerciseOnTrainingAsync(concreteExerciseOnTraining);
                    foreach (Serie serie in SeriesForDataGrid)
                    {
                        if(serie.ConcreteExerciseOnTrainingTrainingHasExerciseId == concreteExerciseOnTraining.TrainingHasExerciseId)
                        {
                            serie.ConcreteExerciseOnTrainingDate = concreteExerciseOnTraining.Date;
                            serie.ConcreteExerciseOnTraining = null;
                            await _serieService.AddSerieAsync(serie);

                        }
                    }
                }
                loadExercisesForTraining();
                SelectedTraining = null;
            }
            else
            {
                MessageBox.Show(App.Current.Resources["PickDateAndTraining"].ToString());
            }
        }

        
       
        private async Task<bool> checkAvailability()
        {
            if(SelectedTraining != null && Date.HasValue)
            {
                ObservableCollection<ConcreteExerciseOnTraining> listForChecking = new ObservableCollection<ConcreteExerciseOnTraining>();
                var exercisesAndSeries = await _trainingHasExerciseService.GetTrainingHasExerciseByTrainingIdAsync(SelectedTraining.Id);
                ObservableCollection<TrainingHasExercise> trainingHasExercises = new ObservableCollection<TrainingHasExercise>(exercisesAndSeries);

                foreach (var training in trainingHasExercises)
                {
                    ConcreteExerciseOnTraining concrete = await _concreteExerciseOnTrainingService.GetConcreteExerciseOnTrainingByTrainingHasExerciseIdAsync(training.Id);

                    if (concrete != null)
                    {
                        listForChecking.Add(concrete);

                    }
                }
                //MessageBox.Show(listForChecking.Count() +"");
                foreach (ConcreteExerciseOnTraining concreteExerciseOnTraining in listForChecking)
                {
                    //MessageBox.Show(concreteExerciseOnTraining.TrainingHasExerciseId + "  " + SelectedTraining.Id + " - " + concreteExerciseOnTraining.Date + "  " + Date.Value);
                    if(concreteExerciseOnTraining.TrainingHasExerciseId == SelectedTraining.Id && concreteExerciseOnTraining.Date.Equals(Date.Value))
                    {

                        MessageBox.Show(App.Current.Resources["TrainingDoneOnThatDate"].ToString());
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
