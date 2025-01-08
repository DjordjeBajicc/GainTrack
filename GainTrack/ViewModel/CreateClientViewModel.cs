using GainTrack.Data.Entities;
using GainTrack.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Windows.Input;
using GainTrack.View.CustomView;

namespace GainTrack.ViewModel
{
    public class CreateClientViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        private string _firstname;
        public string Firstname
        {
            get => _firstname;
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }

        private string _lastname;
        public string Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _rePassword;

        public string RePassword
        {
            get => _rePassword;
            set => SetProperty(ref _rePassword, value);
        }
        public User Trainer { get; set; }

        public ICommand SaveCommand { get; }


        public event EventHandler UserSaved;

        public CreateClientViewModel(IUserService userService)
        {
            _userService = userService;
            SaveCommand = new RelayCommand(SaveUserAsync);
        }

       
        

        private async void SaveUserAsync(object? obj)
        {
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Firstname) && !string.IsNullOrEmpty(Lastname) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(RePassword))
            {
                if (!Password.Equals(RePassword))
                {
                    CustomMessageBox.Show(App.Current.Resources["MakeSureYouReenterThePasseordCorrectly"].ToString());
                    return;
                }
                bool flag = await _userService.CheckAvailabilityOfusername(Username);
                if (!flag)
                {
                    var user = new User
                    {
                        Firstname = Firstname,
                        Lastname = Lastname,
                        Username = Username,
                        Password = Password,
                        Theme = "Dark",
                        Language = "English"
                    };

                    try
                    {
                        await _userService.AddUserAndTraineeAsync(user, Trainer.Id);
                        UserSaved?.Invoke(this, EventArgs.Empty);
                        CustomMessageBox.Show(App.Current.Resources["TheTraineeWasSaved"].ToString());
                        
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    CustomMessageBox.Show(App.Current.Resources["UsernameAlreadyInUse"].ToString());
                }
            }
            else
            {
                CustomMessageBox.Show(App.Current.Resources["FillInAllTheFields"].ToString());
            }
        }
    }
}
