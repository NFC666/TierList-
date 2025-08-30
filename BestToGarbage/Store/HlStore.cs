using System.Collections.ObjectModel;
using Avalonia.Media;
using BestToGarbage.Models;

namespace BestToGarbage.Store;

public class HlStore
{
    public ObservableCollection<HlModel> Items { get; } = new()
    {
        new HlModel
        {
            Tag = "夯",
            HlBackground = new SolidColorBrush(Colors.Red),
            HlForeground = new SolidColorBrush(Colors.Black)
        },
        new HlModel
        {
            Tag = "顶级",
            HlBackground = new SolidColorBrush(Color.FromRgb(255, 136, 0)),
            HlForeground = new SolidColorBrush(Colors.Black)
        },
        new HlModel
        {
            Tag = "人上人",
            HlBackground = new SolidColorBrush(Color.FromRgb(255, 225, 0)),
            HlForeground = new SolidColorBrush(Colors.Black)
        },
        new HlModel
        {
            Tag = "NPC",
            HlBackground = new SolidColorBrush(Color.FromRgb(255, 237, 171)),
            HlForeground = new SolidColorBrush(Colors.Black)
        },
        new HlModel
        {
            Tag = "拉完了",
            HlBackground = new SolidColorBrush(Color.FromRgb(228, 223, 223)),
            HlForeground = new SolidColorBrush(Colors.Black)
        }
    };


    
}