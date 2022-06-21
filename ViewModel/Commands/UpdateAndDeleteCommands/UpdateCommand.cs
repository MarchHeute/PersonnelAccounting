using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace PersonnelAccounting.ViewModel.Commands.UpdateAndDeleteCommands
{
    public class UpdateCommand : ICommand
    {
        public UpdateAndDeleteViewModel? UpdateAndDeleteViewModel { get; private set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public UpdateCommand(UpdateAndDeleteViewModel? updateAndDeleteViewModel)
        {
            UpdateAndDeleteViewModel = updateAndDeleteViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return UpdateAndDeleteViewModel.IsAccountChanged();
        }

        public void Execute(object? parameter)
        {
            UpdateAndDeleteViewModel?.UpdateSelectedAccount(parameter as ListView);
        }
    }
}
