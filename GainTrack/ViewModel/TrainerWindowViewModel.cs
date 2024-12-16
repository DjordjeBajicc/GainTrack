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
    public class TrainerWindowViewModel : INotifyPropertyChanged
    {
        private readonly IUserService _userService;
        private readonly ITraningService _trainingService;
        private readonly IExerciseService _exerciseService;
        private readonly IWeigthExerciseService _weigthExerciseService;
        private readonly ICardioExerciseService _cardioExerciseService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ITrainingHasExerciseService _trainingHasExerciseService;
        private CreateClientViewModel _createClientViewModel;
        private CreateTrainingViewModel _createTrainingViewModel;
        private EditTrainingWindowViewModel _editTrainingWindowViewModel;

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
                LoadTrainingsForUser();
            }
        }

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
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

        public TrainerWindowViewModel(IUserService userService, ITraningService trainingService, IServiceProvider serviceProvider, ITrainingHasExerciseService trainingHasExerciseService, IExerciseService exerciseService, IWeigthExerciseService weigthExerciseService, ICardioExerciseService cardioExerciseService)
        {
            _userService = userService;
            _trainingService = trainingService;
            _serviceProvider = serviceProvider;
            _trainingHasExerciseService = trainingHasExerciseService;
            _exerciseService = exerciseService;
            _weigthExerciseService = weigthExerciseService;
            _cardioExerciseService = cardioExerciseService;

            Users = new ObservableCollection<User>();
            Trainings = new ObservableCollection<Training>();

            AddClientCommand = new RelayCommand(AddClient);
            AddTrainingCommand = new RelayCommand(AddTraining, CanExecuteAddTraining);
            DeleteTrainingCommand = new RelayCommand(DeleteTraining, CanExecuteDeleteTraining);
            SelectUserCommand = new RelayCommand(SelectUser);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            EditTrainingCommand = new RelayCommand(EditTraining);

            LoadUsers();
            LoadAvailableLanguages();
            LoadAvailableThemes();

            _createClientViewModel = _serviceProvider.GetRequiredService<CreateClientViewModel>();
            _createClientViewModel.UserSaved += (sender, e) => LoadUsers();
            
            _createTrainingViewModel = _serviceProvider.GetRequiredService<CreateTrainingViewModel>();

            
        }

        private async void EditTraining(object? obj)
        {
            if (obj is int id)
            {
                // Kreiranje ViewModel-a preko DI i postavljanje ID-a
                EditTrainingWindowViewModel viewModel = new EditTrainingWindowViewModel(_trainingHasExerciseService, _exerciseService, _trainingService, _weigthExerciseService, _cardioExerciseService, id );
               

                // Kreiranje prozora preko DI
                var editTrainingWindow = new EditTrainingWindow(viewModel);

                // Učitavanje podataka pre prikazivanja prozora
                await viewModel.LoadExercisesForTraining();
                await viewModel.LoadExercises();

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

        private void ChangeTheme(object theme)
        {
            if (theme is string && !string.IsNullOrWhiteSpace(theme.ToString()))
            {
                foreach (LanguageTheme lt in AvailableThemes)
                {
                    if (lt.Name.Equals(theme.ToString()))
                    {
                        LanguageAndThemeUtil.ChangeTheme(lt);
                        //MessageBox.Show(ConfigurationManager.AppSettings["TrainerLanguage"]);
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                        config.AppSettings.Settings["TrainerTheme"].Value = theme.ToString();
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        return;
                    }
                }
            }
        }

        private void ChangeLanguage(object language)
        {
            if (language is string  && !string.IsNullOrWhiteSpace(language.ToString()))
            {
                foreach(LanguageTheme lt in AvailableLanguages)
                {
                    if (lt.Name.Equals(language.ToString()))
                    {
                        LanguageAndThemeUtil.ChangeLanguage(lt);
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings["TrainerLanguage"].Value = language.ToString();
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        return;
                    }
                }
            }
        }

        private void SelectUser(object? obj)
        {
           
            LoadTrainingsForUser();
        }

        private async void LoadUsers()
        {
            var usersFromDb = await _userService.GetAllUsersAsync();
            Users = new ObservableCollection<User>(usersFromDb);
        }

        private async void LoadTrainingsForUser()
        {
            if (SelectedUser != null)
            {
                var trainingsFromDb = await _trainingService.GetTrainingsForUserAsync(SelectedUser.Id);
                Trainings = new ObservableCollection<Training>(trainingsFromDb);
            }
            else
            {
                Trainings.Clear();
            }
        }

        private void AddClient(object? obj)
        {
            var createClient = new CreateClient(_createClientViewModel);
            
            createClient.Show();
        }

        private bool CanExecuteAddTraining(object? obj) => SelectedUser != null;

        private void AddTraining(object? obj)
        {
            _createTrainingViewModel.SelectedUser = SelectedUser;
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
