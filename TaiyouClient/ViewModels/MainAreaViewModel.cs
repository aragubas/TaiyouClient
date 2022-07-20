using System;
using Avalonia.Controls;
using ReactiveUI;

namespace TaiyouClient.ViewModels
{
    public class MainAreaViewModel : ViewModelBase
    {
        public static MainAreaViewModel Instance;

        Control _currentContent;
        public Control CurrentContent
        {
            get => _currentContent;
            set => this.RaiseAndSetIfChanged(ref _currentContent, value);
        }

        public MainAreaViewModel()
        {
            Instance = this;
            wsAPI.Connect();
        }

    }
}
