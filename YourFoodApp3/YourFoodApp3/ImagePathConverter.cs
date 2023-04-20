//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Reflection;
//using System.Text;
//using Xamarin.Forms;

//namespace YourFoodApp3
//{
//    public class ImagePathConverter : IValueConverter
//    {
//        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            if (value is string imagePath)
//            {
//                return ImageSource.FromResource(imagePath, typeof(App).GetTypeInfo().Assembly);
//            }
//            return null;
//        }

//        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            throw new NotImplementedException();
//        }
//    }

//}
