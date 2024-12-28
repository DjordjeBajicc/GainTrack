using GainTrack.Utils;
using GainTrack.ViewModel;
using GainTrack.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GainTrack
{
    /// <summary>
    /// Interaction logic for TraineeWindow.xaml
    /// </summary>
    public partial class TraineeWindow : Window
    {
        public TraineeWindow(TraineeWindowViewModel traineeWindowViewModel)
        {
            InitializeComponent();
            DataContext = traineeWindowViewModel;

            string traineeTheme = traineeWindowViewModel.Trainee.Theme;
            string traineeLanguage = traineeWindowViewModel.Trainee.Language;

            // Promeni temu
            if (!string.IsNullOrWhiteSpace(traineeTheme))
            {
                LanguageAndThemeUtil.ChangeTheme(traineeTheme);
            }

            // Promeni jezik
            if (!string.IsNullOrWhiteSpace(traineeLanguage))
            {
                LanguageAndThemeUtil.ChangeLanguage(traineeLanguage);
            }
        }

        private void LanguageButton_Click(object sender, RoutedEventArgs e)
        {
            LanguagePopup.IsOpen = true;
        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            ThemePopup.IsOpen = true;
        }
    }
}
