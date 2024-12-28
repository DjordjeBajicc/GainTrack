using GainTrack.Data;
using GainTrack.Data.Entities;
using GainTrack.Services;
using GainTrack.Utils;
using GainTrack.View;
using GainTrack.ViewModel;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Input;

namespace GainTrack.ViewModels
{
    public class TrainerWindowViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly ITraineeService _traineeService;
        private readonly ITraningService _trainingService;
        private readonly IExerciseService _exerciseService;
        private readonly IWeigthExerciseService _weigthExerciseService;
        private readonly ICardioExerciseService _cardioExerciseService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ITrainingHasExerciseService _trainingHasExerciseService;
        private CreateClientViewModel _createClientViewModel;
        private CreateTrainingViewModel _createTrainingViewModel;
        private EditTrainingWindowViewModel _editTrainingWindowViewModel;

        private User _trainer;

        public User Trainer
        {
            get => _trainer;
            set => SetProperty(ref _trainer, value);
        }

        private Trainee _selectedUser;
        public Trainee SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
                LoadTrainingsForUser();
            }
        }

        private ObservableCollection<Trainee> _trainees;
        public ObservableCollection<Trainee> Trainees
        {
            get => _trainees;
            set
            {
                _trainees = value;
                OnPropertyChanged(nameof(Trainees));
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

        public ObservableCollection<LanguageTheme> AvailableLanguages { get; set; }
        public ICommand ChangeLanguageCommand { get; }
        public ObservableCollection<LanguageTheme> AvailableThemes { get; set; }
        public ICommand ChangeThemeCommand { get; }

        public ICommand AddClientCommand { get; }
        public ICommand AddTrainingCommand { get; }
        public ICommand DeleteTrainingCommand { get; }
        public ICommand SelectUserCommand {  get; }

        public ICommand EditTrainingCommand { get; }

        public TrainerWindowViewModel(IServiceProvider serviceProvider, User user)
        {
            _serviceProvider = serviceProvider;
            _userService = serviceProvider.GetRequiredService<IUserService>() ;
            _traineeService = serviceProvider.GetRequiredService<ITraineeService>();
            _trainingService = serviceProvider.GetRequiredService<ITraningService>();
            
            _trainingHasExerciseService = serviceProvider.GetRequiredService<ITrainingHasExerciseService>();
            _exerciseService = serviceProvider.GetRequiredService<IExerciseService>();
            _weigthExerciseService = serviceProvider.GetRequiredService<IWeigthExerciseService>();
            _cardioExerciseService = serviceProvider.GetRequiredService<ICardioExerciseService>();

            Trainings = new ObservableCollection<Training>();
            Trainees = new ObservableCollection<Trainee>();
            AddClientCommand = new RelayCommand(AddClient);
            AddTrainingCommand = new RelayCommand(AddTraining, CanExecuteAddTraining);
            DeleteTrainingCommand = new RelayCommand(DeleteTraining, CanExecuteDeleteTraining);
            SelectUserCommand = new RelayCommand(SelectUser);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            EditTrainingCommand = new RelayCommand(EditTraining);
            Trainer = user;
            LoadUsers();
            LoadAvailableLanguages();
            LoadAvailableThemes();

            _createClientViewModel = _serviceProvider.GetRequiredService<CreateClientViewModel>();
            _createClientViewModel.UserSaved += (sender, e) => LoadUsers();
            
            _createTrainingViewModel = _serviceProvider.GetRequiredService<CreateTrainingViewModel>();
            _createTrainingViewModel.TrainingAdded += (sender, e) => LoadTrainingsForUser();



        }

        private async void EditTraining(object? obj)
        {
            if (obj is int id)
            {
                // Kreiranje ViewModel-a preko DI i postavljanje ID-a
                EditTrainingWindowViewModel viewModel = new EditTrainingWindowViewModel(_trainingHasExerciseService, _exerciseService, _trainingService, _weigthExerciseService, _cardioExerciseService, id );

                await viewModel.LoadExercisesForTraining();
                // Kreiranje prozora preko DI
                var editTrainingWindow = new EditTrainingWindow(viewModel);

                // Učitavanje podataka pre prikazivanja prozora
                
                //await viewModel.LoadExercises();
                Thread.Sleep(100);
                // Prikaz prozora
                editTrainingWindow.Show();
            }
        }

        private void LoadAvailableLanguages()
        {
            
            AvailableLanguages = LanguageAndThemeUtil.loadLanguagesOrThemes("Resources");
        }

        private void LoadAvailableThemes()
        {

            AvailableThemes = LanguageAndThemeUtil.loadLanguagesOrThemes("Themes");
        }

        private async void ChangeTheme(object theme)
        {
            if (theme is string && !string.IsNullOrWhiteSpace(theme.ToString()))
            {
                foreach (LanguageTheme lt in AvailableThemes)
                {
                    if (lt.Name.Equals(theme.ToString()))
                    {
                        LanguageAndThemeUtil.ChangeTheme(lt);
                        Trainer.Theme = lt.Name;
                        await _userService.UpdateUserThemeAndLanguageAsync(Trainer);
                        return;
                    }
                }
            }
        }

        private async void ChangeLanguage(object language)
        {
            if (language is string  && !string.IsNullOrWhiteSpace(language.ToString()))
            {
                foreach(LanguageTheme lt in AvailableLanguages)
                {
                    if (lt.Name.Equals(language.ToString()))
                    {
                        LanguageAndThemeUtil.ChangeLanguage(lt);
                        Trainer.Language = lt.Name;
                        await _userService.UpdateUserThemeAndLanguageAsync(Trainer);
                        return;
                    }
                }
            }
        }

        private void SelectUser(object? obj)
        {
           
            LoadTrainingsForUser();
        }

        public async void LoadUsers()
        {
            var usersFromDb = await _traineeService.GetTraineeByTrainerId(Trainer.Id);
            Trainees.Clear();  
            foreach (var trainee in usersFromDb)
            {
                Trainees.Add(trainee);  
            }

        }


        private async void LoadTrainingsForUser()
        {
            if (SelectedUser != null)
            {
                var trainingsFromDb = await _trainingService.GetTrainingsForUserAsync(SelectedUser.UserId);
                Trainings.Clear();
                foreach(Training tr in trainingsFromDb)
                {
                    Trainings.Add(tr);
                }
            }
            else
            {
                Trainings.Clear();
            }
        }

        private void AddClient(object? obj)
        {
            _createClientViewModel.Trainer = Trainer;
            var createClient = new CreateClient(_createClientViewModel);
            
            createClient.Show();
        }

        private bool CanExecuteAddTraining(object? obj) => SelectedUser != null;

        private void AddTraining(object? obj)
        {
            _createTrainingViewModel.SelectedUser = SelectedUser.User;
            CreateTraining createTraining = new CreateTraining(_createTrainingViewModel);
            createTraining.Show();
            
        }

        private bool CanExecuteDeleteTraining(object? obj) => obj != null;

        private async void DeleteTraining(object? obj)
        {
            try
            {
                if (obj is int id)
                {
                    Training training = await _trainingService.GetTrainingByIdAsync(id);
                    training.Deleted = 1;
                    await _trainingService.UpdateTrainingAsync(training);
                    Trainings.Remove(training);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
