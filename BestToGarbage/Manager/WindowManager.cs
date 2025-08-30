using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;

namespace BestToGarbage.Manager;

public class WindowManager
{
    private readonly Dictionary<Type, Window> _windows = new();
    private readonly Window _mainWindow;

    public WindowManager(Window mainWindow)
    {
        _mainWindow = mainWindow;
    }

    public T ShowWindow<T>() where T : Window, new()
    {
        var type = typeof(T);

        if (_windows.TryGetValue(type, out var existing) && existing.IsVisible)
        {
            existing.Activate();
            return (T)existing;
        }

        var window = new T();
        
        // 应用标题栏设置
        ApplyWindowChromeSettings(window);
        
        window.Closed += (_, _) => _windows.Remove(type);
        _windows[type] = window;

        window.Show(_mainWindow); // 以 MainWindow 为 owner
        return window;
    }

    // 专门用于创建无标题栏窗口的方法
    public T ShowChromeWindow<T>() where T : Window, new()
    {
        var type = typeof(T);

        if (_windows.TryGetValue(type, out var existing) && existing.IsVisible)
        {
            existing.Activate();
            return (T)existing;
        }

        var window = new T();
        
        // 应用无标题栏设置
        window.ExtendClientAreaToDecorationsHint = true;

        
        window.Closed += (_, _) => _windows.Remove(type);
        _windows[type] = window;

        window.Show(_mainWindow);
        return window;
    }

    private void ApplyWindowChromeSettings(Window window)
    {
        // 根据需要设置标题栏属性
        window.ExtendClientAreaToDecorationsHint = true;
        window.ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.NoChrome;
        
        // 或者根据你的需求设置其他选项
        // window.ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.PreferSystemChrome;
    }

    public void CloseWindow<T>() where T : Window
    {
        var type = typeof(T);
        if (_windows.TryGetValue(type, out var window))
        {
            window.Close();
            _windows.Remove(type);
        }
    }

    public bool IsWindowOpen<T>() where T : Window
    {
        return _windows.ContainsKey(typeof(T));
    }
}