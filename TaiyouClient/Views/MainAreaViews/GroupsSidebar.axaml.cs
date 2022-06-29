using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace TaiyouClient.Views.MainAreaViews
{
    public partial class GroupsSidebar : UserControl
    {
        public GroupsSidebar()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
