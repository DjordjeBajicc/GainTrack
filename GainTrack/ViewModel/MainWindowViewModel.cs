using GainTrack.Data.Entities;
using GainTrack.Services;
using GainTrack.Utils;
using GainTrack.View.CustomView;
using GainTrack.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GainTrack.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private TrainerWindowViewModel _trainerWindowViewModel;
        private readonly IServiceProvider _serviceProvider;
        private TraineeWindowViewModel _traineeWindowViewModel;
        private  ILoginService _loginService;
        private  ITrainerService _trainerService;
        private  ITraineeService _traineeService;
        
        public ICommand LoginCommand { get; }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private User user;

        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            LoginCommand = new RelayCommand(Login);
        }

        private async void Login(object? obj)
        {
            if (Username != null && Password != null)
            {
                _loginService = _serviceProvider.GetRequiredService<ILoginService>();
                user = await _loginService.Login(Username, Password);
                
                if (user != null)
                {
                    _trainerService = _serviceProvider.GetRequiredService<ITrainerService>();
                    Trainer trainer = await _trainerService.GetTrainerById(user.Id);
                    if (trainer != null)
                    {
                        _trainerWindowViewModel = new TrainerWindowViewModel(_serviceProvider, user);

                        TrainerWindow trainerWindow = new TrainerWindow(_trainerWindowViewModel);
                        trainerWindow.Show();
                    }
                    else
                    {
                        _traineeWindowViewModel = new TraineeWindowViewModel(_serviceProvider, user);
                        OpenTraineeWidnow(null);
                    }
                    if(obj is Window main)
                    {
                        main.Close();
                    }
                }
                else
                {
                    CustomMessageBox.Show("Wrong password and/or username");
                }
            }
            else
            {
                CustomMessageBox.Show("Fill in all fields");
            }
        }

        private void OpenTrainerWindow(object? obj)
        {
            

            if (obj is Window currentWindow)
            {
                currentWindow.Close();
            }
        }

        private void OpenTraineeWidnow(object? obj)
        {
            TraineeWindow traineeWindow = new TraineeWindow(_traineeWindowViewModel);
                
            traineeWindow.Show();
            //currentWindow.Close(); 
            
        }
    }
}
