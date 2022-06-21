using System;
using System.Windows.Input;
namespace PersonnelAccounting.ViewModel.Commands.UpdateAndDeleteCommands
{
    public class DeleteCommand : ICommand
    {
        public UpdateAndDeleteViewModel? UpdateAndDeleteViewModel { get; private set; }

        public event EventHandler? CanExecuteChanged;

        public DeleteCommand(UpdateAndDeleteViewModel? updateAndDeleteViewModel)
        {
            UpdateAndDeleteViewModel = updateAndDeleteViewModel;
        }

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
