using System;
using System.Windows.Input;

namespace Tafels
{
    internal class DelegateCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Func<object, bool> canExecute;

        public DelegateCommand(Action<object> action, Func<object, bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            action(parameter);
        }

        public event EventHandler? CanExecuteChanged;
    }
}