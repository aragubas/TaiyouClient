using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using TaiyouClient.ViewModels;

namespace TaiyouClient.Views.MainAreaViews
{
    public partial class GroupsSidebar : UserControl
    {
        public GroupsSidebar()
        {
            InitializeComponent();
        }

        private void GroupsList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
