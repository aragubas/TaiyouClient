using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
