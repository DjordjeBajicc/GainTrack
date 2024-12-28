using GainTrack.Data.Entities;
using GainTrack.Services;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
                UpdateChart();
            }
        }

        // Podaci za grafikon
        private SeriesCollection _chartSeries;
        public SeriesCollection ChartSeries
        {
            get => _chartSeries;
            set => SetProperty(ref _chartSeries, value);
        }

        private string[] _chartLabels;
        public string[] ChartLabels
        {
            get => _chartLabels;
            set => SetProperty(ref _chartLabels, value);
        }

        public ICommand LoadMeasurementsCommand { get; }

        public MessureProgressViewModel(IServiceProvider serviceProvider)
        {
            _messurementService = serviceProvider.GetRequiredService<IMessurementService>();
            Messurements = new ObservableCollection<Messurement>();
            ChartSeries = new SeriesCollection();
            LoadMeasurementsCommand = new RelayCommand(LoadMessurements);

            // Inicijalno učitavanje podataka
            LoadMessurements(null);
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

        private void UpdateChart()
        {
            if (SelectedMeasurement == null) return;

            // Ažuriranje podataka za grafikon
            ChartSeries.Clear();
            ChartSeries.Add(new LineSeries
            {
                Title = SelectedMeasurement.Name,
                Values = new ChartValues<double>(SelectedMeasurement.Values)
            });

            // Ažuriranje oznaka za x-osu
            ChartLabels = Enumerable.Range(1, SelectedMeasurement.Values.Length)
                                     .Select(i => $"Dan {i}")
                                     .ToArray();
        }

    }
}
