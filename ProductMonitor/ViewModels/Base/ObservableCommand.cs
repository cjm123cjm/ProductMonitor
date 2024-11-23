using System;
using System.Windows.Input;

namespace ProductMonitor.ViewModels.Base
{
    public class ObservableCommand : ICommand
    {
        public Action _action;
        public ObservableCommand(Action action)
        {
            _action = action;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action?.Invoke();
        }
    }
}
