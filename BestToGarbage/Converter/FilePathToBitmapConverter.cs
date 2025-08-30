using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;

namespace BestToGarbage.Converter;

public class FilePathToBitmapConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string filePath && !string.IsNullOrEmpty(filePath))
        {
            try
            {
                // 从本地文件路径加载图片
                return new Bitmap(filePath);
            }
            catch (Exception)
            {
                // 如果加载失败，返回 null 或默认图片
                return null;
            }
        }
        return null;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}