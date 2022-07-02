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
            int index = (sender as ListBox).SelectedIndex;

            if (MainAreaViewModel.Instance != null)
            {
                Console.WriteLine((DataContext as GroupsSidebarViewModel).Groups[index]);

                MainAreaViewModel.Instance.CurrentContent = new GroupView();
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
