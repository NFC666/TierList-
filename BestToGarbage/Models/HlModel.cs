

using Avalonia.Media;

namespace BestToGarbage.Models;

public class HlModel
{
    public string Tag { get; set;}
    public SolidColorBrush  HlBackground { get; set;}
    public SolidColorBrush  HlForeground { get; set;}
}
public class HlDto
{
    public string Tag { get; set;}
    public Color  HlBackground { get; set;} = Colors.Blue;
    public Color  HlForeground { get; set;} = Colors.White;
}