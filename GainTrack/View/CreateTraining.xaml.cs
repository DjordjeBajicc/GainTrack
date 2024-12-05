using GainTrack.Data.Entities;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for CreateTraining.xaml
    /// </summary>
    public partial class CreateTraining : Window
    {
        private User _user;
        public CreateTraining(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void ExerciseType_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void AddExerciseToTraining_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateNewExercise_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveTraining_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
