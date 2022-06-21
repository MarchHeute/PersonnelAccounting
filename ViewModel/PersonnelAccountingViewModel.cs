using MongoDB.Driver;
using PersonnelAccounting.Model;
using PersonnelAccounting.ViewModel.Commands.CreatingAccountCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace PersonnelAccounting.ViewModel
{
    public class PersonnelAccountingViewModel : INotifyPropertyChanged
    {
        private IMongoDatabase? _mongoDatabase;


        public CreateCommand? CreateCommand { get; private set; }

        public ReadCommand? ReadCommand { get; private set; }

        public UpdateAndDeleteViewModel? UpdateAndDeleteViewModel { get; private set; }

        private IMongoCollection<Account>? _accounts;

        private string? _selectedAccount;

        public string? SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value?.Replace("Account: ", "");
                UpdateAndDeleteViewModel?.SwitchVisibility(Visibility.Visible);
                UpdateAndDeleteViewModel?.FillFields(GetAccountFromSelectedName());
                OnPropertyChanged(nameof(SelectedAccount));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public PersonnelAccountingViewModel()
        {
            CreateConnection();

            CreateCommand = new CreateCommand(this);
            ReadCommand = new ReadCommand(this);

            UpdateAndDeleteViewModel = new UpdateAndDeleteViewModel(this);
        }

        private void CreateConnection()
        {
            var settings = MongoClientSettings.FromConnectionString($"mongodb+srv://m1adow:{GetPassword()}@personnelaccounting.mnxlj.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            _mongoDatabase = client.GetDatabase("PersonnelAccounting");
        }

        private string? GetPassword()
        {
            string? password = string.Empty;
            string path = $"{Environment.CurrentDirectory}\\password.txt";

            if (!File.Exists(path))
                using (var fileStream = new FileStream(path, FileMode.CreateNew))
                    fileStream.Dispose();

            using (var reader = new StreamReader(path))
            {
                password = reader.ReadToEnd();

                if (password.Length == 0)
                    MessageBox.Show($"You must fill file with location {path}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return password;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ReadDatabase()
        {
            try
            {
                _accounts = _mongoDatabase?.GetCollection<Account>("Accounts");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddAccountIntoDatabase(Account account)
        {
            try
            {
                _accounts?.InsertOne(account);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateAccountInDatabase(Account account)
        {
            try
            {
                _accounts.ReplaceOne(a => a.Nickname == SelectedAccount, account);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private Account? GetAccountFromSelectedName()
        {
            Account? account = new();

            try
            {
                account = _accounts.Find(a => a.Nickname == SelectedAccount).FirstOrDefault();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return account;
        }

        public bool IsAccountsEmpty() => _accounts is not null;

        public List<Account> GetAccounts() => _accounts.AsQueryable().ToList();
    }
}
