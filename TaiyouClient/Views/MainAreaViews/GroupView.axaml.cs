using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using TaiyouClient.Models;
using TaiyouClient.ViewModels;
using TaiyouClient.Views.MainAreaViews.GroupViewViews;

namespace TaiyouClient.Views.MainAreaViews
{
    public partial class GroupView : UserControl
    {
        public GroupView()
        {
            InitializeComponent();
        }

        private void ChannelsListbox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            int index = (sender as ListBox).SelectedIndex;

            if (DataContext != null)
            {
                // Create the channel view
                BasicChannelInfo channel = (DataContext as GroupViewViewModel).Channels[index];
                ChannelView view = new ChannelView();

                (view.DataContext as ChannelViewViewModel).LoadChannel(channel);

                (DataContext as GroupViewViewModel).CurrentContent = view;
            }

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
