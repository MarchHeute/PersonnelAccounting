using PersonnelAccounting.Model;
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

        private string? _job;

        public string? Job
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

        public event PropertyChangedEventHandler? PropertyChanged;

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
            Job = account?.Owner?.Job?.Name;
            Salary = account?.Owner?.Job?.Salary;
        }
    }
}
