using MongoDB.Driver;

namespace PersonnelAccounting.ViewModel
{
    public class PersonnelAccountingViewModel
    {
        public IMongoDatabase? MongoDatabase { get; private set; }

        public PersonnelAccountingViewModel()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://m1adow:<password>@personnelaccounting.mnxlj.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            MongoDatabase = client.GetDatabase("PersonnelAccounting");
        }
    }
}
