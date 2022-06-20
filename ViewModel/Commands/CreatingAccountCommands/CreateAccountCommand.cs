using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace PersonnelAccounting.ViewModel.Commands.CreatingAccountCommands
{
    public class CreateAccountCommand : ICommand
    {
        public CreateAccountViewModel? CreateAccountViewModel { get; private set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CreateAccountCommand(CreateAccountViewModel? createAccountViewModel)
        {
            CreateAccountViewModel = createAccountViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return CreateAccountViewModel.IsFieldsFilled();
        }

        public void Execute(object? parameter)
        {
            CreateAccountViewModel?.CreateAccount(parameter as ComboBox);
        }
    }
}
