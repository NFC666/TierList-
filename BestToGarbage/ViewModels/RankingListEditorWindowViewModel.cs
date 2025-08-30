using System.Collections.ObjectModel;
using Avalonia.Media;
using BestToGarbage.Manager;
using BestToGarbage.Message;
using BestToGarbage.Models;
using BestToGarbage.Views.Dialog;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BestToGarbage.ViewModels;

public partial class RankingListEditorWindowViewModel : ViewModelBase
{
    [ObservableProperty] private HlDto _model = new HlDto();


    public ObservableCollection<HlModel> Items => Program.Store.Items;
    
    [RelayCommand]
    public void Add()
    {
        var hlModel = new HlModel()
        {
            Tag = Model.Tag,
            HlBackground = new SolidColorBrush(Model.HlBackground),
            HlForeground = new SolidColorBrush(Model.HlForeground),
        };
        Program.Store.Items.Add(hlModel);
    }

    [RelayCommand]
    public void Up(HlModel model)
    {
        int i = Items.IndexOf(model);
        if (i > 0)
        {
            Items.Move(i, i - 1);
        }
    }
    [RelayCommand]
    public void Down(HlModel model)
    {
        int i = Items.IndexOf(model);
        if (i < Items.Count - 1)
        {
            Items.Move(i, i + 1);
        }
        
    }

    [RelayCommand]
    public void Delete(HlModel model)
    {
        Items.Remove(model);
    }

    [RelayCommand]
    public void Clear()
    {
        Model = new HlDto();
    }
    

}