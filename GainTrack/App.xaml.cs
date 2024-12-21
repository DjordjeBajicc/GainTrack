using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Configuration; // Za čitanje App.config
using System.Windows;
using GainTrack.Data;
using GainTrack.Services;
using GainTrack.ViewModel;
using GainTrack.ViewModels;
using GainTrack.Utils;
using GainTrack.View;

namespace GainTrack
{
    public partial class App : Application
    {
        private IHost _host;
        public static GainTrackContext DbContext { get; private set; }

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                // Dobavljanje konekcijskog stringa iz App.config
                    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                    // Dodavanje DbContext-a
                    services.AddDbContext<GainTrackContext>(options =>
                        options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));


                    services.AddScoped<IUserService, UserService>();
                    services.AddScoped<ICardioExerciseService, CardioExerciseService>();
                    services.AddScoped<IWeigthExerciseService, WeigthExerciseService>();
                    services.AddScoped<ITrainingHasExerciseService, TrainingHasExerciseService>();
                    services.AddScoped<IExerciseService, ExerciseService>();
                    services.AddScoped<ITraningService, TrainingService>();
                    services.AddScoped<IConcreteExerciseOnTrainingService, ConcreteExerciseOnTrainingService>();
                    services.AddScoped<ISerieService, SerieService>();
                    // Registracija ViewModel-a
                    services.AddScoped<TrainerWindowViewModel>();
                    services.AddScoped<MainWindowViewModel>();
                    services.AddScoped<TrainingDoneViewModel>();
                    services.AddScoped<CreateClientViewModel>();
                    services.AddScoped<TrainerWindow>();
                    services.AddScoped<MainWindow>();
                    services.AddScoped<CreateClient>();
                    services.AddScoped<TraineeWindowViewModel>();
                    services.AddScoped<CreateTraining>();
                    services.AddScoped<CreateTrainingViewModel>();
                    services.AddScoped<TrainingsViewModel>();

                    // Registracija prozora
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            // Pokretanje servisa i otvaranje glavnog prozora
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            // Čekanje na startovanje hosta
            

            // Dozvoljava automatsko upravljanje DbContext instancama preko DI
            DbContext = _host.Services.GetRequiredService<GainTrackContext>();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            // Zaustavljanje hosta prilikom izlaska iz aplikacije
            await _host.StopAsync();
            _host.Dispose();

            // Oslobađanje resursa poveznih sa DbContext
            DbContext.Dispose();
            base.OnExit(e);
        }

        
    }
}
