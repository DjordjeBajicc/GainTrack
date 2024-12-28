using GainTrack.Data.Entities;
using GainTrack.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GainTrack.ViewModel
{
    public class AddMessurementViewModel : BaseViewModel
    {
        private readonly IMessurementService _messurementService;
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand CreateCommand { get; }

        private Messurement _choosenMessurement;

        private ObservableCollection<Messurement> _messurements;

        public ObservableCollection<Messurement> Messurements
        {
            get => _messurements;
            set
            {
                _messurements = value;
                OnPropertyChanged(nameof(Messurements));
            }
        }

        public Messurement ChoosenMessurement
        {
            get => _choosenMessurement;
            set
            {
                _choosenMessurement = value;
                OnPropertyChanged(nameof(ChoosenMessurement));
            }
        }

        private decimal _value;
        public decimal Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        public User Trainee { get; set; }

        public ICommand SaveCommand { get; }

        public AddMessurementViewModel(IServiceProvider serviceProvider, User trainee)
        {
            Trainee = trainee;
            _messurementService = serviceProvider.GetRequiredService<IMessurementService>();
            CreateCommand = new RelayCommand(Create);
            SaveCommand = new RelayCommand(SaveMessure);
            Messurements = new ObservableCollection<Messurement>();
            LoadMessurements();
        }

        private async void Create(object? obj)
        {
            
            if (!string.IsNullOrEmpty(Name))
            {
                bool flag = await _messurementService.ExistsByName(Name);
                if (!flag) 
                {
                    Messurement messurement = new Messurement
                    {
                        Name = Name
                    };
                    await _messurementService.CreateMessurement(messurement);
                    LoadMessurements();
                    MessageBox.Show(App.Current.Resources["MessurementCreated"].ToString());
                }
                else
                {
                    MessageBox.Show(App.Current.Resources["MessurementAlreadyExists"].ToString());
                }
            }
            else
            {
                MessageBox.Show(App.Current.Resources["EnterTheNameOfMessurement"].ToString());
            }
        }

        private async void SaveMessure(object? obj)
        {
            if (ChoosenMessurement != null && Value != 0)
            {
                UserHasMessurement userHasMessurement = new UserHasMessurement
                {
                    TraineeId = Trainee.Id,
                    MessurementName = ChoosenMessurement.Name,
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    Value = Value
                };
                bool flag = await _messurementService.ExistsByNameAndDateAndUser(userHasMessurement);
                if (!flag)
                {
                    await _messurementService.AddNewMessure(userHasMessurement);
                    MessageBox.Show(App.Current.Resources["MessureRecorded"].ToString());
                }
                else
                {
                    MessageBox.Show(App.Current.Resources["MessureAlreadyExistsForThisDate"].ToString());
                }
            }
            else
            {
                MessageBox.Show(App.Current.Resources["ChooseMessurementAndEnterTheValue"].ToString());
            }
        }

        private async void LoadMessurements()
        {
            Messurements.Clear();
            var messurements = await _messurementService.GetMessurementsAsync();
            foreach(var m in messurements)
            {
                Messurements.Add(m);
            }
        }

    }
}
