using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace BestToGarbage.Converter;

public class ItemsCountToHeightConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is int count)
        {
            int itemHeight = 120;
            int margin = 2;
            return count * itemHeight + count * margin;
        }
        return 450; // 默认高度
    }
    
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}