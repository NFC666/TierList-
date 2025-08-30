using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using BestToGarbage.Models;

namespace BestToGarbage.Views.Dialog;

public partial class MessageDialog : Window
{
    public MessageDialog(TutorialContentModel content)
    {
        InitializeComponent();
        TitleText.Text = content.Title;
        ContentText.Text = content.Content;
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}