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
                string groupId = (DataContext as GroupsSidebarViewModel).Groups[index].Id;
                GroupView groupView = new();

                (groupView.DataContext as GroupViewViewModel).LoadGroup(groupId);

                MainAreaViewModel.Instance.CurrentContent = groupView;

            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
