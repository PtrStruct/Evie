using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Evie.Converters
{
    public class ByteArrayToBitmapSourceConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ToBitmapSource(value as byte[]);
        }

        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ToByteArray(value as BitmapSource);
        }

        public static BitmapSource ToBitmapSource(byte[] buffer)
        {
            BitmapSource bitmap = null;

            if (buffer != null)
            {
                using (var stream = new MemoryStream(buffer))
                {
                    bitmap = BitmapFrame.Create(
                        stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
            }

            return bitmap;
        }

        public static byte[] ToByteArray(BitmapSource bitmap)
        {
            byte[] buffer = null;

            if (bitmap != null)
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));

                using (var stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    buffer = stream.ToArray();
                }
            }

            return buffer;
        }
    }
}
