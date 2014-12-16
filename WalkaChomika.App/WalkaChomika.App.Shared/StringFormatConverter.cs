using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace WalkaChomika.App
{
    public class JednostkaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return string.Format(parameter.ToString(), value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return 7; //Dla Konrada
        }
    }
}