using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using TaiyouClient.Views;

namespace TaiyouClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel Instance;
        Control _currentContent;

        public Control CurrentContent
        {
            get => _currentContent;
            set => this.RaiseAndSetIfChanged(ref _currentContent, value);
        }


        public MainWindowViewModel()
        {
            Instance = this;

            if (API.LoadStoredUser())
            {
                CurrentContent = new MainArea();

            }
            else
            {
                CurrentContent = new LoginScreen();
            }

        }
    }

}
