using System.Collections.ObjectModel;
using Avalonia.Media;
using BestToGarbage.Message;
using BestToGarbage.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BestToGarbage.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isShow = false;
    [ObservableProperty] private HlMemberViewModel _showMember;
    public ObservableCollection<HlModel> Items => Program.Store.Items;

    public MainWindowViewModel()
    {
        WeakReferenceMessenger.Default.Register<ShowMemberMessage>(this, (w, m) =>
        {
            IsShow = true;
            ShowMember = m.MemberViewModel;
            
        });
        WeakReferenceMessenger.Default.Register<NotShowMemberMessage>(this, (w, m) =>
        {
            IsShow = false;
        });
    }
    
}