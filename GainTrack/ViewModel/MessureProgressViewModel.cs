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

        private User Trainee {  get; set; }
        public ICommand LoadMeasurementsCommand { get; }

        public MessureProgressViewModel(IServiceProvider serviceProvider, User trainee)
        {
            _messurementService = serviceProvider.GetRequiredService<IMessurementService>();
            Messurements = new ObservableCollection<Messurement>();
            ChartSeries = new SeriesCollection();
            LoadMeasurementsCommand = new RelayCommand(LoadMessurements);

            // Inicijalno učitavanje podataka
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

        private async void UpdateChart()
        {
            if (SelectedMeasurement != null)
            {
                ChartSeries.Clear();
                var uhms = await _messurementService.GetUserHasMessurementsByTraineeAndMessurement(Trainee, SelectedMeasurement);
                ObservableCollection<decimal> values = new ObservableCollection<decimal>();
                ObservableCollection<UserHasMessurement> userHasMessurements = new ObservableCollection<UserHasMessurement>(uhms);
                foreach(var tmp in uhms)
                {
                    values.Add(tmp.Value);
                }
                ChartSeries.Add( new ColumnSeries{
                                Title = SelectedMeasurement.Name,
                                Values = new ChartValues<decimal>(values),
                                DataLabels = true, // Formatiranje etikete
                                Foreground = new SolidColorBrush(Colors.LightBlue)});
                ChartLabels = userHasMessurements
                            .Where((_, index) => index % 5 != 0) // Prikazuje svaki peti datum
                            .Select(m => m.Date.ToString("dd.MM"))
                            .ToArray();
            }
            else
            {

                MessageBox.Show("");
            }


            //// Ažuriranje podataka za grafikon
            //ChartSeries.Clear();
            //ChartSeries.Add(new LineSeries
            //{
            //    Title = SelectedMeasurement.Name,
            //    Values = new ChartValues<double>(SelectedMeasurement.Values)
            //});

            //// Ažuriranje oznaka za x-osu
            //ChartLabels = Enumerable.Range(1, SelectedMeasurement.Values.Length)
            //                         .Select(i => $"Dan {i}")
            //                         .ToArray();
        }

    }
}
