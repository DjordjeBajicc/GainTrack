using GainTrack.Utils;
using GainTrack.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GainTrack.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly TrainerWindowViewModel _trainedWindowViewModel;
        private readonly IServiceProvider _serviceProvider;
        private TraineeWindowViewModel _traineeWindowViewModel;
        public ICommand TrainerWindowCommand { get; }
        public ICommand TraineeWindowCommand { get; }

        public MainWindowViewModel(TrainerWindowViewModel trainerWindowViewModel, IServiceProvider serviceProvider)
        {
            _trainedWindowViewModel = trainerWindowViewModel;
            _serviceProvider = serviceProvider;
            TrainerWindowCommand = new RelayCommand(OpenTrainerWindow);
            TraineeWindowCommand = new RelayCommand(OpenTraineeWidnow);
        }

        private void OpenTrainerWindow(object? obj)
        {
           
            var trainerWindow = _serviceProvider.GetRequiredService<TrainerWindow>();
            
            trainerWindow.Show();

            // Zatvaranje trenutnog prozora
            if (obj is Window currentWindow)
            {
                currentWindow.Close();
            }
        }

        private void OpenTraineeWidnow(object? obj)
        {
            
            if (obj is Window currentWindow)
            {
                _traineeWindowViewModel = _serviceProvider.GetRequiredService<TraineeWindowViewModel>();
                
                TraineeWindow traineeWindow = new TraineeWindow(_traineeWindowViewModel);
                
                traineeWindow.Show();
                currentWindow.Close(); 
            }
        }
    }
}
