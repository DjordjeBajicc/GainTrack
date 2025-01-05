using GainTrack.Data.Entities;
using GainTrack.Services;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GainTrack.ViewModel
{
    public class MessureProgressViewModel : BaseViewModel
    {
        private readonly IMessurementService _messurementService;


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

        private Messurement _selectedMeasurement;
        public Messurement SelectedMeasurement
        {
            get => _selectedMeasurement;
            set
            {
                SetProperty(ref _selectedMeasurement, value);
                LoadTraineeMessurements();
            }
        }

        private ObservableCollection<UserHasMessurement> _userHasMessurements;

        public ObservableCollection<UserHasMessurement> UserHasMessurements
        {
            get => _userHasMessurements;
            set
            {
                _userHasMessurements = value;
                OnPropertyChanged(nameof(UserHasMessurements));
            }
        }

        

        private User Trainee {  get; set; }
        public ICommand LoadMeasurementsCommand { get; }

        public MessureProgressViewModel(IServiceProvider serviceProvider, User trainee)
        {
            _messurementService = serviceProvider.GetRequiredService<IMessurementService>();
            Messurements = new ObservableCollection<Messurement>();
            
            LoadMeasurementsCommand = new RelayCommand(LoadMessurements);
            UserHasMessurements = new ObservableCollection<UserHasMessurement>();
            
            LoadMessurements(null);
            Trainee = trainee;
        }

        private async void LoadMessurements(object? obj)
        {
            Messurements.Clear();
            var messurements = await _messurementService.GetMessurementsAsync();
            foreach (var m in messurements)
            {
                Messurements.Add(m);
            }
        }

        private async void LoadTraineeMessurements()
        {
            if (SelectedMeasurement != null)
            {
                UserHasMessurements.Clear();
                var uhms = await _messurementService.GetUserHasMessurementsByTraineeAndMessurement(Trainee, SelectedMeasurement);

                foreach (var m in uhms)
                {
                    UserHasMessurements.Add(m);
                }
            }
        }


    }
}
