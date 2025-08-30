using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using BestToGarbage.Manager;
using BestToGarbage.Message;
using BestToGarbage.ViewModels;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BestToGarbage.Views;

public partial class MainWindow : Window
{
    ObservableCollection<Image> _images = new();
    private Image? _currentImage;
    private bool _isImageFollowingMouse;
    private double _imageWidth = 140; // 图片宽度
    private double _imageHeight = 130; // 图片高度
    
    private readonly WindowManager _windowManager;

    public MainWindow()
    {
        // 设置为手动定位
        this.WindowStartupLocation = WindowStartupLocation.Manual;

        // 设置窗口位置（相对于屏幕左上角）
        this.Position = new PixelPoint(600, 100); // x=600, y=100

        // 初始化
        InitializeComponent();
        
        // 设置数据上下文
        DataContext = new MainWindowViewModel();

        // 创建窗口管理器
        _windowManager = new WindowManager(this);
        
        // 设置Canvas事件
        DragCanvas.PointerMoved += OnCanvasPointerMoved;
        DragCanvas.PointerPressed += OnCanvasPointerPressed;
        DragCanvas.PointerReleased += OnCanvasPointerReleased; // 添加释放事件
        WeakReferenceMessenger.Default.Register<MovingMemberMessage>(this, 
            (w, m) =>
            {
                var newImage = new Image()
                {
                    Source = new Bitmap(m.HlMember.ImgPath),
                    Width = _imageWidth,
                    Height = _imageHeight,
                    Stretch = Stretch.Fill
                };
        
                // 为每个图片创建独立的删除命令
                newImage.ContextMenu = new ContextMenu()
                {
                    Items =
                    {
                        new MenuItem()
                        {
                            Header = "删除",
                            Command = new RelayCommand(() =>
                            {
                                DragCanvas.Children.Remove(newImage);
                                _images.Remove(newImage);
                            })
                        }
                    }
                };
        
                _images.Add(newImage);
                _currentImage = newImage;
                DragCanvas.Children.Add(_currentImage);
                _isImageFollowingMouse = true;
            });
    }

    private void OnCanvasPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (_isImageFollowingMouse && _currentImage != null && e.GetCurrentPoint(DragCanvas).Properties.IsLeftButtonPressed)
        {
            var point = e.GetPosition(DragCanvas);
            // 设置图片中心跟随鼠标
            Canvas.SetLeft(_currentImage, point.X - _imageWidth / 2);
            Canvas.SetTop(_currentImage, point.Y - _imageHeight / 2);
        }
    }

    private void OnCanvasPointerMoved(object? sender, PointerEventArgs e)
    {
        if (_isImageFollowingMouse && _currentImage != null)
        {
            var point = e.GetPosition(DragCanvas);
            // 设置图片中心跟随鼠标
            Canvas.SetLeft(_currentImage, point.X - _imageWidth / 2);
            Canvas.SetTop(_currentImage, point.Y - _imageHeight / 2);
        }
    }

    private void OnCanvasPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        if (_isImageFollowingMouse && _currentImage != null && e.InitialPressMouseButton == MouseButton.Left)
        {
            // 停止图片跟随鼠标，但保留图片在Canvas上
            _isImageFollowingMouse = false;

        }
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        OpenEditor();
        OpenMemberPage();
    }

    private void OpenEditor()
    {
        _windowManager.ShowChromeWindow<RankingListEditorWindow>();
    }

    private void OpenMemberPage()
    {
        _windowManager.ShowChromeWindow<RankingMemberWindow>();
    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            this.BeginMoveDrag(e); // 调用 Avalonia 内置的拖动
        }
    }

    private void OpenEditor(object? sender, RoutedEventArgs e)
    {
        OpenEditor();
    }
    private void OpenMemberPage(object? sender, RoutedEventArgs e)
    {
        OpenMemberPage();
    }
}