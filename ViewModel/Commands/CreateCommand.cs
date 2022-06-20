using System;
using System.Windows.Input;

namespace PersonnelAccounting.ViewModel.Commands
{
    public class CreateCommand : ICommand
    {
        public PersonnelAccountingViewModel? PersonnelAccountingViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public CreateCommand(PersonnelAccountingViewModel? personnelAccountingViewModel)
        {
            PersonnelAccountingViewModel = personnelAccountingViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            
        }
    }
}
