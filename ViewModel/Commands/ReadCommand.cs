using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace PersonnelAccounting.ViewModel.Commands
{
    public class ReadCommand : ICommand
    {
        public PersonnelAccountingViewModel? PersonnelAccountingViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;       

        public ReadCommand(PersonnelAccountingViewModel? personnelAccountingViewModel)
        {
            PersonnelAccountingViewModel = personnelAccountingViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
            //return PersonnelAccountingViewModel?.MongoDatabase is not null;
        }

        public void Execute(object? parameter)
        {
            PersonnelAccountingViewModel?.ReadDatabase();

            ListView? listView = parameter as ListView;

            listView?.Items.Clear();

            foreach (var account in PersonnelAccountingViewModel.Accounts)
                listView?.Items.Add(account);
        }
    }
}
