using MongoDB.Driver;
using System;
using System.IO;
using System.Windows;

namespace PersonnelAccounting.ViewModel
{
    public class PersonnelAccountingViewModel
    {
        public IMongoDatabase? MongoDatabase { get; private set; }

        public PersonnelAccountingViewModel()
        {
            var settings = MongoClientSettings.FromConnectionString($"mongodb+srv://m1adow:{GetPassword()}@personnelaccounting.mnxlj.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            MongoDatabase = client.GetDatabase("PersonnelAccounting");
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
    }
}
