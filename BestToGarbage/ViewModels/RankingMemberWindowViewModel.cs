using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using BestToGarbage.Message;
using BestToGarbage.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BestToGarbage.ViewModels;

public partial class RankingMemberWindowViewModel : ViewModelBase
{
    public ObservableCollection<HlMemberViewModel> Items { get; set; }
        = new();

    [RelayCommand]
    private async Task AddImgMember(Window parentWindow)
    {
        // 获取 StorageProvider
        var storageProvider = parentWindow.StorageProvider;

        // 配置文件选择选项
        var options = new FilePickerOpenOptions
        {
            Title = "选择一个文件",
            AllowMultiple = true, 
            FileTypeFilter = new[]
            {
                new FilePickerFileType("图像文件")
                {
                    Patterns = new[] { "*.jpg", "*.png", "*.gif", "*.jpeg", "*.bmp", "*.tiff", "*.webp" }
                }
            }
        };

        // 显示文件选择对话框
        var files = await storageProvider.OpenFilePickerAsync(options);

        // 处理选择结果
        if (files.Any())
        {
            foreach (var file in files)
            {
                Items.Add(new HlMemberViewModel
                {
                    Name = file.Name,
                    ImgPath = file.Path.LocalPath
                });
            }

        }
    }
    

}