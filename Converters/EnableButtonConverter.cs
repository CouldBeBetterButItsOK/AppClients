using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace WPF_MVVM_SPA_Template.Converters
{
    public class EnableButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Comprueba si el valor es un array de strings
            if (value is string[] fields)
            {
                // Comprueba si todos los campos tienen valores
                return fields.All(field => !string.IsNullOrWhiteSpace(field));
            }
            return false; // Deshabilita el botón si no es un array
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}