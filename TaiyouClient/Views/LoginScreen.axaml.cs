using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using System;
using TaiyouClient.ViewModels;

namespace TaiyouClient.Views
{
    public partial class LoginScreen : ReactiveUserControl<LoginScreenViewModel>
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
