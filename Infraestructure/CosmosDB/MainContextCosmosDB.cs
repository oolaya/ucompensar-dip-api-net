using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domian.Port;
using MongoDB.Driver;

namespace Infraestructure
{
    public class MainContextCosmosDB : IMainContextCosmos
    {
        private IMongoDatabase Db { get; set; }

        private MongoClient MongoClient { get; set; }

        public MainContextCosmosDB(IConfigurateCosmosDB configurateCosmosDB)
        {
            MongoClient = new MongoClient(configurateCosmosDB.ConnectionString);
            Db = MongoClient.GetDatabase(configurateCosmosDB.DatabaseName);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string name) 
        {
            return !string.IsNullOrEmpty(name) ? Db.GetCollection<TEntity>(name):null;
        }
    }
}
