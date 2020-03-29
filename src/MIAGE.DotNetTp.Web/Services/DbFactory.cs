using MongoDB.Driver;

namespace MIAGE.DotNetTp.Web.Services
{
    public class DbFactory : IDbFactory
    {
        private MongoClient _client;
        public IMongoDatabase Database { get; private set; }

        public DbFactory(string host)
        {
            _client = new MongoClient(host);
            Database = _client.GetDatabase("MiageTD");
        }
    }
}
