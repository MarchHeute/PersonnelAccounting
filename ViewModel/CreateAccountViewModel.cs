using PersonnelAccounting.Model;
using PersonnelAccounting.Model.Jobs;
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
            Job job = GetJob(Job?.Text);

            Account = new Account()
            {
                Nickname = this.Nickname,
                Owner = new Owner()
                {
                    Firstname = this.Firstname,
                    Lastname = this.Lastname,
                    Job = job
                }
            };

            Nickname = String.Empty;
            Firstname = String.Empty;
            Lastname = String.Empty;
            comboBox.SelectedIndex = -1;
        }

        private Job GetJob(string? jobName)
        {
            return jobName switch
            {
                nameof(Barista) => new Barista(),
                nameof(Farrier) => new Farrier(),
                nameof(Seller) => new Seller(),
                nameof(Turner) => new Turner(),
                _ => throw new Exception("This job is not exits"),
            };
        }
    }
}
