using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TaiyouClient.Views
{
    public partial class TopBar : UserControl
    {
        public TopBar()
        {
            InitializeComponent();

            this.FindControl<StackPanel>("UserAreaWidget").DataContext = GlobalState.Instance;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
