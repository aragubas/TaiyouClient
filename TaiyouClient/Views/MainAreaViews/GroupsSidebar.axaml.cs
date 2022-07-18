using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using TaiyouClient.Models;
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
            int index = (sender as ListBox).SelectedIndex;

            if (MainAreaViewModel.Instance != null && DataContext != null)
            {
                GroupView groupView = new GroupView();
                MainAreaViewModel.Instance.CurrentContent = groupView;
                (groupView.DataContext as GroupViewViewModel).LoadGroup((DataContext as GroupsSidebarViewModel).Groups[index].Id);

            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
