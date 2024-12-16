using GainTrack.Data.Entities;
using GainTrack.Services;
using GainTrack.Utils;
using GainTrack.ViewModel;
using GainTrack.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TrainerWindow.xaml
    /// </summary>
    public partial class TrainerWindow : Window
    {
        public TrainerWindow(TrainerWindowViewModel trainerWindowViewModel)
        {
            InitializeComponent();
            DataContext = trainerWindowViewModel;
            string trainerTheme = ConfigurationManager.AppSettings["TrainerTheme"];
            string trainerLanguage = ConfigurationManager.AppSettings["TrainerLanguage"];

            // Promeni temu
            if (!string.IsNullOrWhiteSpace(trainerTheme))
            {
                LanguageAndThemeUtil.ChangeTheme(trainerTheme);
            }

            // Promeni jezik
            if (!string.IsNullOrWhiteSpace(trainerLanguage))
            {
                LanguageAndThemeUtil.ChangeLanguage(trainerLanguage);
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

        
        private void OnTrainingDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Proverite da li je dvokliknut pravi ListBoxItem
            if (sender is ListBoxItem listBoxItem && listBoxItem.DataContext is Training training)
            {
                // Pozovite komandu iz ViewModel-a, ako postoji
                if (DataContext is TrainerWindowViewModel viewModel)
                {
                    viewModel.EditTrainingCommand.Execute(training.Id);
                    //MessageBox.Show("1");
                }
                //MessageBox.Show("2");
            }
            
        }

    
}
}
