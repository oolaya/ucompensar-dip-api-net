using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Port
{
    public interface IMainContextCosmos:IMainContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string name);
    }
}
