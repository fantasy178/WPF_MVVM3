using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_MVVM3
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> executeCommand;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action<object> execute)
        {
            executeCommand = execute;
        }
        public RelayCommand(Action<object> execute, Func<bool> canExecute)
        {
            this.canExecute = canExecute;
            executeCommand = execute;
        }

        public bool CanExecute(object parameter) => canExecute == null || canExecute();

        public void Execute(object parameter) => executeCommand(parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }            
        }
    }
}
