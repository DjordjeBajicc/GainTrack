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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;

namespace GainTrack.View
{
    /// <summary>
    /// Interaction logic for MyTrainings.xaml
    /// </summary>
    public partial class MyTrainings : Page
    {
        public MyTrainings(TrainingDoneViewModel trainingDoneViewModel)
        {
            InitializeComponent();
            DataContext = trainingDoneViewModel;
        }

        private void NumberOnly_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }

        private void Decimal_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !decimal.TryParse(e.Text, out _);
        }

        private void TimeOnly_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, @"^([0-1]?[0-9]|2[0-3]):([0-5]?[0-9]):([0-5]?[0-9])$"))
            {
                textBox.Text = string.Empty;
                SaveButton.IsEnabled = false;
            }
            else
            {
                SaveButton.IsEnabled = true;
            }
        }



    }
}
