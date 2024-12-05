using GainTrack.Data.Entities;
using GainTrack.Services;
using GainTrack.ViewModel;
using GainTrack.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        }

        private void ClientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                
        }

        //private void AddClient_Click(object sender, RoutedEventArgs e)
        //{
        //    CreateClient createClient = new CreateClient(_userService);
        //    createClient.Show();
        //}

        private void AddTraining_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
