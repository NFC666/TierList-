using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using BestToGarbage.Models;
using BestToGarbage.ViewModels;
using BestToGarbage.Views.Dialog;

namespace BestToGarbage.Views;

public partial class RankingMemberWindow : Window
{
    public RankingMemberWindow()
    {
        InitializeComponent();
        DataContext = new RankingMemberWindowViewModel();
    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        this.BeginMoveDrag(e);
    }


}