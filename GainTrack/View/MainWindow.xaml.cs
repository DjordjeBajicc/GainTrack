using GainTrack.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GainTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHost _host;
        private IUserService _userService;
        public MainWindow(IUserService UserService, IHost host)
        {
            InitializeComponent();
            _host = host;
            _userService = UserService;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenTraineeWindow_Click(object sender, RoutedEventArgs e)
        {
            TraineeWindow traineeWindow = new TraineeWindow();
            traineeWindow.Show();
        }

        private void OpenTrainerWindow_Click(object sender, RoutedEventArgs e)
        {
            var trainerWindow = _host.Services.GetRequiredService<TrainerWindow>();
            trainerWindow.Show();
        }
    }
}