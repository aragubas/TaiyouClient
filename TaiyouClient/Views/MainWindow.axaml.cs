using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace TaiyouClient.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);

#if DEBUG
            this.AttachDevTools();
#endif

            // Fixes the window content getting out of window when maximized (Source: https://github.com/FrankenApps/Avalonia-CustomTitleBarTemplate/blob/master/Views/CustomTitleBars/WindowsTitleBar.axaml.cs)
            Window hostWindow = (Window)this.VisualRoot;

            hostWindow.GetObservable(Window.WindowStateProperty).Subscribe(state =>
            {
                if (state == WindowState.Maximized)
                {
                    hostWindow.Padding = new Thickness(7, 7, 7, 7);
                } 
                else
                {
                    hostWindow.Padding = new Thickness(1, 1, 1, 1);
                }
            });

        }
    }
}
