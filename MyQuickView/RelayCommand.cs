using System;
using System.Windows.Input;

namespace QuickAccess
{
    public class RelayCommand : ICommand
    {
        private Action commandTask;

        public RelayCommand(Action workToDo)
        {
            commandTask = workToDo;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            commandTask();
        }
    }
}
