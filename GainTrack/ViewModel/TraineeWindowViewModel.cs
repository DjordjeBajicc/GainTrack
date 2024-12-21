using GainTrack.Data;
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
        public ObservableCollection<LanguageTheme> AvailableLanguages { get; set; }

        public ObservableCollection<LanguageTheme> AvailableThemes { get; set; }
        public ICommand showTrainingsCommand { get; }
        public ICommand showTrainingsHistoryCommand { get; }
        public ICommand showProgressCommand { get; }
        public ICommand enterMessurementsCommand { get; }

        public ICommand ChangeThemeCommand { get; }
        public ICommand ChangeLanguageCommand { get; }

        private UserControl _currentView;
        public UserControl CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                //MessageBox.Show($"CurrentView changed to: {_currentView.GetType().Name}");
                OnPropertyChanged(nameof(CurrentView)); // Obaveštava UI da je došlo do promene
            }
        }
        public TraineeWindowViewModel(IServiceProvider serviceProvider)
        {
            _trainingDoneViewModel = serviceProvider.GetRequiredService<TrainingDoneViewModel>();
            _trainingingsViewModel = serviceProvider.GetRequiredService<TrainingsViewModel>();
            showTrainingsCommand = new RelayCommand(ShowTrainings);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            showTrainingsHistoryCommand = new RelayCommand(ShowHistory);
            ShowHistory(null);
            LoadAvailableLanguages();
            LoadAvailableThemes();
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
            CurrentView = new TrainingDone(_trainingDoneViewModel);
            Application.Current.Dispatcher.Invoke(() => CurrentView.UpdateLayout());

        }

        public void ShowHistory(object? obj)
        {
            //MessageBox.Show("111");
            
            _trainingingsViewModel.loadTrainigNamesAndDates();
            CurrentView = new Trainings(_trainingingsViewModel);
            Application.Current.Dispatcher.Invoke(() => CurrentView.UpdateLayout());
            //MessageBox.Show("111222");
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
                        
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                        config.AppSettings.Settings["TraineeTheme"].Value = theme.ToString();
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        
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
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings["TraineeLanguage"].Value = language.ToString();
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                       
                        return;
                    }
                }
            }
        }
    }
}
