using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GainTrack.Converters
{
    public class RadioButtonToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Ako je SelectedExerciseType null ili prazan string, ne vrši ništa
            return value?.ToString() == parameter.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Ako je RadioButton označen, vrati parametar (npr. "All", "Weight", "Cardio")
            return (bool)value ? parameter.ToString() : null;
        }
    }
}
