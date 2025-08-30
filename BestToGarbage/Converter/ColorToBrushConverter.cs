using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace BestToGarbage.Converter;

public class ColorToBrushConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Color color)
        {
            return new SolidColorBrush(color);
        }
        return Brushes.Transparent; // 默认值，防止绑定失败
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is SolidColorBrush brush)
        {
            return brush.Color;
        }
        return default(Color); // 默认值，防止绑定失败
    }
}