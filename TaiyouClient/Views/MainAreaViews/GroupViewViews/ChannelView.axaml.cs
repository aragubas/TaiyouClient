using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TaiyouClient.Views.MainAreaViews.GroupViewViews
{
    public partial class ChannelView : UserControl
    {
        public ChannelView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
