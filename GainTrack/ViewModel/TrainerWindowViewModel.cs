using GainTrack.Data.Entities;
using GainTrack.Services;
using GainTrack.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace GainTrack.ViewModels
{
    public class TrainerWindowViewModel : INotifyPropertyChanged
    {
        private readonly IUserService _userService;
        private readonly ITraningService _trainingService;

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

        public ICommand AddClientCommand { get; }
        public ICommand AddTrainingCommand { get; }
        public ICommand DeleteTrainingCommand { get; }

        public TrainerWindowViewModel(IUserService userService, ITraningService trainingService)
        {
            _userService = userService;
            _trainingService = trainingService;

            Users = new ObservableCollection<User>();
            Trainings = new ObservableCollection<Training>();

            AddClientCommand = new RelayCommand(AddClient);
            AddTrainingCommand = new RelayCommand(AddTraining, CanExecuteAddTraining);
            DeleteTrainingCommand = new RelayCommand(DeleteTraining, CanExecuteDeleteTraining);

            LoadUsers();
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

        private void AddClient()
        {
            CreateClient createClient = new CreateClient(_userService);
            createClient.Show();
        }

        private bool CanExecuteAddTraining() => SelectedUser != null;

        private void AddTraining()
        {
            // Logika za dodavanje treninga
        }

        private bool CanExecuteDeleteTraining() => SelectedUser != null && Trainings.Count > 0;

        private void DeleteTraining()
        {
            if (SelectedUser != null && Trainings.Count > 0)
            {
                // Logika za brisanje treninga
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
