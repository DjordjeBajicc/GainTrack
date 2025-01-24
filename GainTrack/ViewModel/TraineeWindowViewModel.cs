using GainTrack.Data;
using GainTrack.Data.Entities;
using GainTrack.Services;
using GainTrack.Utils;
using GainTrack.View;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GainTrack.ViewModel
{
    public class TraineeWindowViewModel : BaseViewModel
    {
        private readonly TrainingDoneViewModel _trainingDoneViewModel;
        private readonly TrainingsViewModel _trainingingsViewModel;
        private ExerciseProgressViewModel _exerciseProgressViewModel;
        private AddMessurementViewModel _addMessurementViewModel;
        private MessureProgressViewModel _messureProgressViewModel;
        private MainWindowViewModel _mainWindowViewModel;
        private IServiceProvider _serviceProvider;
        private ChangeUsernameAndPasswordViewModel _changeUsernameAndPasswordViewModel;
        private readonly IUserService _userService;
        private User _trainee;

        public User Trainee
        {
            get => _trainee;
            set => SetProperty(ref _trainee, value);
        }


        public ObservableCollection<LanguageTheme> AvailableLanguages { get; set; }

        public ObservableCollection<LanguageTheme> AvailableThemes { get; set; }

        private int _selectedTabIndex;
        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set
            {
                _selectedTabIndex = value;
                OnPropertyChanged(nameof(SelectedTabIndex));
                UpdateCurrentView();
            }
        }

        public Page MyTrainingsPage { get; set; }
        public Page TrainingHistoryPage { get; set; }
        public Page EnterMessurementsPage { get; set; }
        public Page MessurementProgressPage { get; set; }
        public Page ExerciseProgressPage { get; set; }
        public ICommand ChangeThemeCommand { get; }
        public ICommand ChangeLanguageCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand UpdateCommand { get; }
        public TraineeWindowViewModel(IServiceProvider serviceProvider, User trainee)
        {
            _serviceProvider = serviceProvider;
            _userService = serviceProvider.GetRequiredService<IUserService>();
            Trainee = trainee;

            _addMessurementViewModel = new AddMessurementViewModel(serviceProvider, trainee);
            _messureProgressViewModel = new MessureProgressViewModel(serviceProvider, Trainee);
            _exerciseProgressViewModel = new ExerciseProgressViewModel(serviceProvider, Trainee);
            _trainingDoneViewModel = new TrainingDoneViewModel(serviceProvider, Trainee);
            _trainingingsViewModel = new TrainingsViewModel(serviceProvider, Trainee);
            _mainWindowViewModel = new MainWindowViewModel(serviceProvider);
            _changeUsernameAndPasswordViewModel = new ChangeUsernameAndPasswordViewModel(serviceProvider, Trainee);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            LogoutCommand = new RelayCommand(Logout);
            UpdateCommand = new RelayCommand(Update);
            MyTrainingsPage = new MyTrainings(_trainingDoneViewModel);
            TrainingHistoryPage = new TrainingHistory(_trainingingsViewModel);
            EnterMessurementsPage = new AddMessurement(_addMessurementViewModel);
            MessurementProgressPage = new MessureProgress(_messureProgressViewModel);
            ExerciseProgressPage = new ExerciseProgress(_exerciseProgressViewModel);
            LoadAvailableLanguages();
            LoadAvailableThemes();
        }

        private void Update(object? obj)
        {
            _changeUsernameAndPasswordViewModel = new ChangeUsernameAndPasswordViewModel(_serviceProvider, Trainee);
            ChangeUsernameAndPassword changeUsernameAndPassword = new ChangeUsernameAndPassword(_changeUsernameAndPasswordViewModel);
            changeUsernameAndPassword.ShowDialog();
        }
        private void Logout(object? obj)
        {
            if (obj is Window window)
            {

                MainWindow mainWindow = new MainWindow(_mainWindowViewModel);
                mainWindow.Show();
                window.Close();
            }
        }
        
        private void UpdateCurrentView()
        {
            switch (SelectedTabIndex)
            {
                case 0:
                    _trainingDoneViewModel.loadTrainings();
                    break;
                case 1:
                    _trainingingsViewModel.loadTrainigNamesAndDates();
                    break;
                case 2:
                    
                    break;
                case 3:
                    _messureProgressViewModel.LoadMeasurementsCommand.Execute(null);
                    break;
                case 4:
                    _exerciseProgressViewModel.FilterExercises();
                    break;
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
                        Trainee.Theme = lt.Name;
                        _userService.UpdateUserThemeAndLanguageAsync(Trainee);
                        return;
                    }
                }
            }
        }

        private void ChangeLanguage(object language)
        {
            if (language is string && !string.IsNullOrWhiteSpace(language.ToString()))
            {
                foreach (LanguageTheme lt in AvailableLanguages)
                {
                    if (lt.Name.Equals(language.ToString()))
                    {
                        LanguageAndThemeUtil.ChangeLanguage(lt);
                        Trainee.Language = lt.Name;
                        _userService.UpdateUserThemeAndLanguageAsync(Trainee);
                        return;
                    }
                }
            }
        }
    }
}
