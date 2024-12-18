using GainTrack.ViewModel;
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
    /// Interaction logic for CreateExercise.xaml
    /// </summary>
    public partial class CreateExercise : Window
    {
        public CreateExercise(CreateExerciseViewModel createExerciseViewModel)
        {
            InitializeComponent();
            DataContext = createExerciseViewModel;
        }

        

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
