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

        public string Firstname {  get; set; }
        public string Lastname { get; set; }

        public ICommand SaveCommand { get; }

        public event EventHandler UserSaved;

        public CreateClientViewModel(IUserService userService)
        {
            _userService = userService;
            SaveCommand = new RelayCommand(async () => await SaveUserAsync(), CanSaveUser);
        }

        private bool CanSaveUser()
        {
            return !string.IsNullOrEmpty(Firstname) && !string.IsNullOrEmpty(Lastname);
        }

        private async Task SaveUserAsync()
        {
            var user = new User
            {
                Firstname = Firstname,
                Lastname = Lastname,
                Trainer = int.Parse(ConfigurationManager.AppSettings["TrainerId"])
            };

            try
            {
                await _userService.AddUserAsync(user);
                UserSaved?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Vjezbac je sacuvan.");
                Firstname = string.Empty;
                Lastname = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
