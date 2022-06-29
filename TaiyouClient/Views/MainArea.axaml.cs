using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TaiyouClient.Views
{
    public partial class MainArea : UserControl
    {
        public MainArea()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
