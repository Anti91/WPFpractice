using System;
using System.Windows.Input;

namespace WPFsumApp.MVVM
{
    internal class DelegateCommand : ICommand
    {
        private Action viewModelCommandExecute;

        public DelegateCommand(Action viewModelCommandExecute)
        {
            this.viewModelCommandExecute = viewModelCommandExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModelCommandExecute.Invoke();
        }
    }
}