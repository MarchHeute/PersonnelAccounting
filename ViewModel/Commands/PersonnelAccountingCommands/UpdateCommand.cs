using System;
using System.Windows.Input;
namespace PersonnelAccounting.ViewModel.Commands.CreatingAccountCommands
{
    public class UpdateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
