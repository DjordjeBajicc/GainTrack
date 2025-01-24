using GainTrack.Data.Entities;
using GainTrack.Services;
using GainTrack.View.CustomView;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GainTrack.ViewModel
{
    public class ChangeUsernameAndPasswordViewModel : BaseViewModel
    {
        private IUserService _userService;
        private User _user;
        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _rePassword;

        public string RePassword
        {
            get => _rePassword;
            set => SetProperty(ref _rePassword, value);
        }

        private string _oldPassword;

        public string OldPassword
        {
            get => _oldPassword;
            set => SetProperty(ref _oldPassword, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand SaveCommand { get; }

        public ChangeUsernameAndPasswordViewModel(IServiceProvider serviceProvider, User user)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();
            _user = user;
            Username = user.Username;

            SaveCommand = new RelayCommand(Save);
        }

        private async void Save(object? obj)
        {
            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(RePassword) && string.IsNullOrEmpty(OldPassword))
            {
                CustomMessageBox.Show(App.Current.Resources["FillInNewUsernameOrNewPassword"].ToString());
            }
            else
            {
                bool flag1 = false;
                bool flag2 = false;
                if (!string.IsNullOrEmpty(Username))
                {
                    bool flag = await _userService.CheckAvailabilityOfusername(Username);
                    if (flag)
                    {
                        CustomMessageBox.Show(App.Current.Resources["UsernameAlreadyInUse"].ToString());
                        return;
                    }
                    _user.Username = Username;
                    flag1 = true;
                }

                if (!string.IsNullOrEmpty(Password))
                {
                    if (string.IsNullOrEmpty(OldPassword) || !_user.Password.Equals(OldPassword))
                    {
                        CustomMessageBox.Show(App.Current.Resources["EnterCorrectOldPassword"].ToString());
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(RePassword) && !string.IsNullOrEmpty(RePassword) && RePassword.Equals(Password))
                        {
                            _user.Password = Password;
                            flag2 = true;
                        }
                        else
                        {
                            CustomMessageBox.Show(App.Current.Resources["MakeSureYouReenterThePasseordCorrectly"].ToString());
                        }
                    }
                }

                if (flag1 || flag2)
                {
                    _userService.UpdateUser(_user);
                    CustomMessageBox.Show(App.Current.Resources["SuccessifulUpdate"].ToString());
                    if (flag1)
                    {
                        Username = string.Empty;
                    }

                    if (flag2)
                    {
                        Password = string.Empty;
                        RePassword = string.Empty;
                    }
                }
            }
        }
    }
}
