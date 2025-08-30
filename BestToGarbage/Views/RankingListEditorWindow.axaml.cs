using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using BestToGarbage.Manager;
using BestToGarbage.Models;
using BestToGarbage.ViewModels;
using BestToGarbage.Views.Dialog;

namespace BestToGarbage.Views;

public partial class RankingListEditorWindow : Window
{
    private readonly WindowManager _windowManager;
    public RankingListEditorWindow()
    {
        _windowManager = new WindowManager(this);
        // 设置为手动定位
        this.WindowStartupLocation = WindowStartupLocation.Manual;
        
        // 设置窗口位置（相对于屏幕左上角）
        this.Position = new PixelPoint(100, 100); // x=100, y=100
        
        InitializeComponent();
        DataContext = new RankingListEditorWindowViewModel();

    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        this.BeginMoveDrag(e);
    }
    

}