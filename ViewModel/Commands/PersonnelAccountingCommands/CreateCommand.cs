using PersonnelAccounting.View;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace PersonnelAccounting.ViewModel.Commands.CreatingAccountCommands
{
    public class CreateCommand : ICommand
    {
        public PersonnelAccountingViewModel? PersonnelAccountingViewModel { get; private set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CreateCommand(PersonnelAccountingViewModel? personnelAccountingViewModel)
        {
            PersonnelAccountingViewModel = personnelAccountingViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return PersonnelAccountingViewModel.IsAccountsEmpty();
        }

        public void Execute(object? parameter)
        {
            CreateAccount createAccount = new();
            createAccount.ShowDialog();

            var createAccountViewModel = createAccount.DataContext as CreateAccountViewModel;

            PersonnelAccountingViewModel?.AddAccountIntoDatabase(createAccountViewModel.Account);

            PersonnelAccountingViewModel?.ReadCommand.Execute(parameter as ListView);
        }
    }
}
