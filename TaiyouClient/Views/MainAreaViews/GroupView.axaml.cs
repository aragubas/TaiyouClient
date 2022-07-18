using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using TaiyouClient.Models;
using TaiyouClient.ViewModels;

namespace TaiyouClient.Views.MainAreaViews
{
    public partial class GroupView : UserControl
    {
        int lastIndex = -1;
        public GroupView()
        {
            InitializeComponent();
        }

        private void ChannelsListbox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            int index = (sender as ListBox).SelectedIndex;
            lastIndex = index;

            if (DataContext != null)
            {
                //ChannelView channelView = new ChannelView();

                Console.WriteLine((DataContext as GroupViewViewModel).Channels[index].Name);

                //(channelView.DataContext as ChannelViewViewModel).LoadGroup((DataContext as GroupsSidebarViewModel).Groups[index].Id);

            }

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
