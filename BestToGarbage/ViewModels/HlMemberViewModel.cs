using BestToGarbage.Message;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BestToGarbage.ViewModels;

public partial class HlMemberViewModel : ViewModelBase
{
    public string Name { get; set; }
    public string ImgPath { get; set; }
    
    [RelayCommand]
    private void ShowMember(HlMemberViewModel member)
    {
        WeakReferenceMessenger.Default.Send(new ShowMemberMessage(member));
    }

    [RelayCommand]
    private void NotShowMember()
    {
        WeakReferenceMessenger.Default.Send(new NotShowMemberMessage());
    }
    
    [RelayCommand]
    private void MovingMember(HlMemberViewModel member)
    {
        WeakReferenceMessenger.Default.Send(new MovingMemberMessage(member));
    }
}