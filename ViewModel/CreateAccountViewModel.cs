using PersonnelAccounting.Model;
using PersonnelAccounting.ViewModel.Commands.CreatingAccountCommands;
using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace PersonnelAccounting.ViewModel
{
    public class CreateAccountViewModel : INotifyPropertyChanged
    {
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

        public Account? Account { get; private set; }

        public CreateAccountCommand? CreateAccountCommand { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public CreateAccountViewModel()
        {
            CreateAccountCommand = new CreateAccountCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsFieldsFilled()
        {
            if (Nickname is null || Firstname is null || Lastname is null || Job is null)
                return false;

            return true;
        }

        public void CreateAccount(ComboBox? comboBox)
        {
            Random random = new();

            Account = new Account
            {
                Nickname = this.Nickname,
                Owner = new Owner
                {
                    Firstname = this.Firstname,
                    Lastname = this.Lastname,
                    Job = new Job
                    {
                        Name = Job.Text,
                        Index = this.Index,
                        Salary = random.Next(100, 300)
                    }
                }
            };

            Nickname = String.Empty;
            Firstname = String.Empty;
            Lastname = String.Empty;
            Salary = null;
            comboBox.SelectedIndex = -1;
        }
    }
}
