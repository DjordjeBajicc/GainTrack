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
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Firstname) && !string.IsNullOrEmpty(Lastname))
            {
                var user = new User
                {
                    Firstname = Firstname,
                    Lastname = Lastname,
                    Username = Username,
                    Theme = "Dark",
                    Language = "English"
                };

                try
                {
                    await _userService.AddUserAndTraineeAsync(user, Trainer.Id);
                    UserSaved?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(App.Current.Resources["TheTraineeWasSaved"].ToString());
                    Firstname = string.Empty;
                    Lastname = string.Empty;
                    Username = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(App.Current.Resources["FillInAllTheFields"].ToString());
            }
        }
    }
}
