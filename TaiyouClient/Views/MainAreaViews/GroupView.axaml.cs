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
        public GroupView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
