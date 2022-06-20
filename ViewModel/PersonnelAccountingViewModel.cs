using MongoDB.Driver;
using System;
using System.IO;

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

        private string GetPassword()
        {
            using var reader = new StreamReader($"{Environment.CurrentDirectory}\\password.txt");
            return reader.ReadToEnd();
        }
    }
}
