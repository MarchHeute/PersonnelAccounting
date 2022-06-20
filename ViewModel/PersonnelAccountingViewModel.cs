using MongoDB.Driver;
using PersonnelAccounting.Model;
using PersonnelAccounting.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace PersonnelAccounting.ViewModel
{
    public class PersonnelAccountingViewModel
    {
        private IMongoDatabase? _mongoDatabase;

        public List<Account>? Accounts { get; set; }

        public ReadCommand? ReadCommand { get; set; }

        public PersonnelAccountingViewModel()
        {
            var settings = MongoClientSettings.FromConnectionString($"mongodb+srv://m1adow:{GetPassword()}@personnelaccounting.mnxlj.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            _mongoDatabase = client.GetDatabase("PersonnelAccounting");

            Accounts = new List<Account>();
            ReadCommand = new ReadCommand(this);
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

        public void ReadDatabase() => Accounts = _mongoDatabase?.GetCollection<Account>("accounts").AsQueryable().ToList();
    }
}
