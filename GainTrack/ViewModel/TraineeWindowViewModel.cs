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

namespace GainTrack.ViewModel
{
    public class TraineeWindowViewModel : BaseViewModel
    {
        private readonly TrainingDoneViewModel _trainingDoneViewModel;
        private readonly TrainingsViewModel _trainingingsViewModel;
        private ExerciseProgressViewModel _exerciseProgressViewModel;
        private AddMessurementViewModel _addMessurementViewModel;
        private MessureProgressViewModel _messureProgressViewModel;
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
                OnPropertyChanged();
                UpdateCurrentView();
            }
        }
        public ICommand showTrainingsCommand { get; }
        public ICommand showTrainingsHistoryCommand { get; }
        public ICommand showProgressCommand { get; }
        public ICommand enterMessurementsCommand { get; }

        public ICommand ChangeThemeCommand { get; }
        public ICommand ChangeLanguageCommand { get; }

        private Page _currentView;
        public Page CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }
        public TraineeWindowViewModel(IServiceProvider serviceProvider, User trainee)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();
            Trainee = trainee;
            _trainingDoneViewModel = serviceProvider.GetRequiredService<TrainingDoneViewModel>();
            _trainingDoneViewModel.Trainee = trainee;
            _trainingingsViewModel = serviceProvider.GetRequiredService<TrainingsViewModel>();
            _trainingingsViewModel.Trainee = trainee;


            _addMessurementViewModel = new AddMessurementViewModel(serviceProvider, trainee);
            _messureProgressViewModel = new MessureProgressViewModel(serviceProvider, Trainee);
            _exerciseProgressViewModel = new ExerciseProgressViewModel(serviceProvider, Trainee);
            showTrainingsCommand = new RelayCommand(ShowTrainings);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            showTrainingsHistoryCommand = new RelayCommand(ShowHistory);
            //ShowAddMessurements(null);
            //ShowHistory(null);
            //ShowTrainings(null);
            //ShowMessurementProgress(null);
            ShowExerciseProgress(null);
            LoadAvailableLanguages();
            LoadAvailableThemes();
        }

        private void UpdateCurrentView()
        {
            switch (SelectedTabIndex)
            {
                case 0:
                    ShowTrainings(null);
                    break;
                case 1:
                    ShowHistory(null);
                    break;
                case 2:
                    ShowExerciseProgress(null);
                    break;
                case 3:
                   ShowAddMessurements(null); 
                    break;
                case 4:
                    ShowMessurementProgress(null); 
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
        public void ShowTrainings(object? obj)
        {
            _trainingDoneViewModel.loadTrainings();
            Application.Current.Dispatcher.Invoke(() => CurrentView = new MyTrainings(_trainingDoneViewModel));
        }

        public void ShowHistory(object? obj)
        {
            _trainingingsViewModel.loadTrainigNamesAndDates();
            //CurrentView = new TrainingHistory(_trainingingsViewModel);
            Application.Current.Dispatcher.Invoke(() => CurrentView = new TrainingHistory(_trainingingsViewModel));
        }

        public void ShowAddMessurements(object? obj)
        {
            Application.Current.Dispatcher.Invoke(() => CurrentView = new AddMessurement(_addMessurementViewModel));
        }

        public void ShowMessurementProgress(object? obj)
        {
            Application.Current.Dispatcher.Invoke(() => CurrentView = new MessureProgress(_messureProgressViewModel));
        }

        public void ShowExerciseProgress(object? obj)
        {
            Application.Current.Dispatcher.Invoke(() => CurrentView = new ExerciseProgress(_exerciseProgressViewModel));
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
