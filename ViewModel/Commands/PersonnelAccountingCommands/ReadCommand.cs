using MongoDB.Driver;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace PersonnelAccounting.ViewModel.Commands.CreatingAccountCommands
{
    public class ReadCommand : ICommand
    {
        public PersonnelAccountingViewModel? PersonnelAccountingViewModel { get; private set; }

        public event EventHandler? CanExecuteChanged;

        public ReadCommand(PersonnelAccountingViewModel? personnelAccountingViewModel)
        {
            PersonnelAccountingViewModel = personnelAccountingViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            PersonnelAccountingViewModel?.ReadDatabase();

            ListView? listView = parameter as ListView;

            listView?.Items.Clear();

            if (PersonnelAccountingViewModel.Accounts is not null)
            {
                foreach (var account in PersonnelAccountingViewModel.Accounts.AsQueryable().ToList())
                    listView?.Items.Add($"Account: {account.Nickname}");
            }
        }
    }
}
