using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TaiyouClient.Views.MainAreaViews
{
    public partial class UserDashboard : UserControl
    {
        public UserDashboard()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
