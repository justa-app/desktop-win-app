using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WindowsApplication.DataObjects;

namespace WindowsApplication.Converters
{
    internal class ArrayToIndexConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            
            object[] arr = (object[])values[0];
            int index = (int)values[1];
            if(arr.Length > index)
            {
                RelevantDocumentData data = arr[index] as RelevantDocumentData;
                RelevantDocument d = new RelevantDocument();
                d.DataContext = data;
                d.AddClick += data.GetDefaultBrowserPath;
                return d;
            } else 
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
