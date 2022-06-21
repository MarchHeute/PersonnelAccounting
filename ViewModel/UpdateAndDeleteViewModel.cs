using PersonnelAccounting.Model;
using PersonnelAccounting.ViewModel.Commands.UpdateAndDeleteCommands;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PersonnelAccounting.ViewModel
{
    public class UpdateAndDeleteViewModel : INotifyPropertyChanged
    {
        private Visibility _visibility = Visibility.Collapsed;

        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged(nameof(Visibility));
            }
        }

        private string? _nickname;

        public string? Nickname
        {
            get => _nickname;
            set
            {
                _nickname = value;
                OnPropertyChanged(nameof(Nickname));
            }
        }

        private string? _firstname;

        public string? Firstname
        {
            get => _firstname;
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }

        private string? _lastname;

        public string? Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        private TextBlock? _job;

        public TextBlock? Job
        {
            get => _job;
            set
            {
                _job = value;
                OnPropertyChanged(nameof(Job));
            }
        }

        private int? _index;

        public int? Index
        {
            get => _index;
            set
            {
                _index = value;
                OnPropertyChanged(nameof(Index));
            }
        }

        private decimal? _salary;

        public decimal? Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }

        public PersonnelAccountingViewModel? PersonnelAccountingViewModel { get; private set; }

        public UpdateCommand? UpdateCommand { get; private set; }

        public DeleteCommand? DeleteCommand { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private Account? _selectedAccount;
        private Account? _createdAccount;

        public UpdateAndDeleteViewModel(PersonnelAccountingViewModel personnelAccountingViewModel)
        {
            PersonnelAccountingViewModel = personnelAccountingViewModel;

            UpdateCommand = new UpdateCommand(this);
            DeleteCommand = new DeleteCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SwitchVisibility(Visibility visibility) => Visibility = visibility;

        public void FillFields(Account? account)
        {
            Nickname = account?.Nickname;
            Firstname = account?.Owner?.Firstname;
            Lastname = account?.Owner?.Lastname;
            Index = account?.Owner?.Job?.Index;
            Salary = account?.Owner?.Job?.Salary;

            _selectedAccount = account;
        }

        public bool IsAccountChanged()
        {
            if (this.Job is null)
                return false;

            if (_selectedAccount is null)
                return false;

            _createdAccount = new()
            {
                Id = _selectedAccount.Id,
                Nickname = this.Nickname,
                Owner = new Owner
                {
                    Firstname = this.Firstname,
                    Lastname = this.Lastname,
                    Job = new Job
                    {
                        Index = this.Index,
                        Name = this.Job.Text,
                        Salary = this.Salary
                    }
                }
            };

            return _selectedAccount.Nickname != _createdAccount.Nickname ||
                _selectedAccount.Owner.Firstname != _createdAccount.Owner.Firstname ||
                _selectedAccount.Owner.Lastname != _createdAccount.Owner.Lastname ||
                _selectedAccount.Owner.Job.Index != _createdAccount.Owner.Job.Index ||
                _selectedAccount.Owner.Job.Salary != _createdAccount.Owner.Job.Salary;
        }

        public void UpdateSelectedAccount(ListView? listView)
        {
            PersonnelAccountingViewModel?.UpdateAccountInDatabase(_createdAccount);
            PersonnelAccountingViewModel?.ReadCommand.Execute(listView);
            ClearFields();
        }

        private void ClearFields()
        {
            Visibility = Visibility.Collapsed;
            Nickname = String.Empty;
            Firstname = String.Empty;
            Lastname = String.Empty;
            Index = -1;
            Salary = null;
        }
    }
}
